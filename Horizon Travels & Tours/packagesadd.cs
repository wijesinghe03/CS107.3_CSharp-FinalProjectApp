using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace horizon_travels_and_tours
{
    public partial class packagesadd : Form
    {
        private packageClass package = new packageClass();
        private bool isUpdating = false; 

        public packagesadd()
        {
            InitializeComponent();
        }

        bool Verify()
        {
            return !string.IsNullOrEmpty(textBox_pname.Text) &&
                   !string.IsNullOrEmpty(textBox_pdescription.Text) &&
                   !string.IsNullOrEmpty(textBox_pdays.Text) &&
                   !string.IsNullOrEmpty(textBox_pprice.Text) &&
                   pictureBox_package.Image != null;
        }

        private void packagesadd_Load(object sender, EventArgs e)
        {
            showTable();
        }

        public void showTable()
        {
            DataGridView_package.DataSource = package.getPackageList();
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)DataGridView_package.Columns[6];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }

        private void DataGridView_package_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DataGridView_package.CurrentRow != null)
            {
                textBox_pid.Text = DataGridView_package.CurrentRow.Cells[0].Value.ToString();
                textBox_pname.Text = DataGridView_package.CurrentRow.Cells[1].Value.ToString();
                textBox_pdescription.Text = DataGridView_package.CurrentRow.Cells[2].Value.ToString();
                textBox_pcountry.Text = DataGridView_package.CurrentRow.Cells[3].Value.ToString();
                textBox_pprice.Text = DataGridView_package.CurrentRow.Cells[4].Value.ToString();
                textBox_pdays.Text = DataGridView_package.CurrentRow.Cells[5].Value.ToString();

                if (DataGridView_package.CurrentRow.Cells[6].Value != null)
                {
                    if (DataGridView_package.CurrentRow.Cells[6].Value is Image)
                    {
                        pictureBox_package.Image = (Image)DataGridView_package.CurrentRow.Cells[6].Value;
                    }
                    else if (DataGridView_package.CurrentRow.Cells[6].Value is byte[])
                    {
                        byte[] img = (byte[])DataGridView_package.CurrentRow.Cells[6].Value;
                        using (MemoryStream ms = new MemoryStream(img))
                        {
                            pictureBox_package.Image = Image.FromStream(ms);
                        }
                    }
                }
            }
        }

        private void button_uploadp_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.gif)|*.jpg;*.jpeg;*.png;*.gif";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox_package.Image = Image.FromFile(opf.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    opf.Dispose();
                }
            }
        }

        private void button_addp_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Verify())
                {
                    showTable();
                    MessageBox.Show("Please fill in all the fields and select an image.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string pName = textBox_pname.Text;
                string pdescription = textBox_pdescription.Text;
                string country = textBox_pcountry.Text;
                int price, days;
                if (!int.TryParse(textBox_pprice.Text, out price))
                {
                    MessageBox.Show("Please enter a valid price.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!int.TryParse(textBox_pdays.Text, out days))
                {
                    MessageBox.Show("Please enter a valid number of days.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                byte[] pimage;
                using (MemoryStream ms = new MemoryStream())
                {
                    pictureBox_package.Image.Save(ms, pictureBox_package.Image.RawFormat);
                    pimage = ms.ToArray();
                }

                if (package.insertPackage(pName, pdescription, country, price, days, pimage))
                {
                    MessageBox.Show("New Package Details Added!", "Add Package", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showTable();
                }
                else
                {
                    MessageBox.Show("Package not Inserted", "Add Package", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_clearp_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            textBox_pid.Clear();
            textBox_pname.Clear();
            textBox_pdescription.Clear();
            textBox_pprice.Clear();
            textBox_pdays.Clear();
            textBox_pcountry.Clear();
            pictureBox_package.Image = null;
            isUpdating = false;
        }

        private void button_searchp_Click(object sender, EventArgs e)
        {
            DataGridView_package.DataSource = package.searchPackageList(textBox_searchp.Text);
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)DataGridView_package.Columns[6];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }



        private void button_deletep_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Verify())
                {
                    MessageBox.Show("Please fill in all the fields and select an image.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int pid = Convert.ToInt32(textBox_pid.Text);

                if (package.deletePackage(pid))
                {
                    MessageBox.Show("Package deleted successfully!", "Delete Package", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    
                    if (DataGridView_package.SelectedRows.Count > 0)
                    {
                        DataGridView_package.Rows.RemoveAt(DataGridView_package.SelectedRows[0].Index);
                    }
                }
                else
                {
                    MessageBox.Show("Failed to delete package.", "Delete Package", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_updatep_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!Verify())
                {
                    showTable();
                    MessageBox.Show("Please fill in all the fields and select an image.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int pid = Convert.ToInt32(textBox_pid.Text);
                string pName = textBox_pname.Text;
                string pdescription = textBox_pdescription.Text;
                string country = textBox_pcountry.Text;
                int price, days;

                if (!int.TryParse(textBox_pprice.Text, out price))
                {
                    MessageBox.Show("Please enter a valid price.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(textBox_pdays.Text, out days))
                {
                    MessageBox.Show("Please enter a valid number of days.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                byte[] pimage;

                
                if (pictureBox_package.Image != null)
                {
                    
                    using (MemoryStream ms = new MemoryStream())
                    {
                        pictureBox_package.Image.Save(ms, pictureBox_package.Image.RawFormat);
                        pimage = ms.ToArray();
                    }
                }
                else
                {
                   
                    pimage = null;
                }

                if (package.updatePackage(pid, pName, pdescription, country, price, days, pimage))
                {
                    MessageBox.Show("Package details updated successfully!", "Update Package", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showTable(); 
                }
                else
                {
                    MessageBox.Show("Failed to update package.", "Update Package", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}

