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
using System.IO;


namespace horizon_travels_and_tours
{
    public partial class deleteCustomerdetails : Form
    {
        CustomerClass customer = new CustomerClass();
        public deleteCustomerdetails()
        {
            InitializeComponent();
        }

        private void deleteCustomerdetails_Load(object sender, EventArgs e)
        {
            showTable();
        }
        public void showTable()
        {
            DataGridView_customer.DataSource = customer.getCustomerList();
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)DataGridView_customer.Columns[8];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;

        }

        private void DataGridView_customer_Click(object sender, EventArgs e)
        {
            textBox_id.Text = DataGridView_customer.CurrentRow.Cells[0].Value.ToString();
            textBox_fname.Text = DataGridView_customer.CurrentRow.Cells[1].Value.ToString();
            textBox_lname.Text = DataGridView_customer.CurrentRow.Cells[2].Value.ToString();
            textBox_address.Text = DataGridView_customer.CurrentRow.Cells[3].Value.ToString();

            dateTimePicker1.Value = (DateTime)DataGridView_customer.CurrentRow.Cells[4].Value;
            if (DataGridView_customer.CurrentRow.Cells[5].Value.ToString() == "Male")
                radioButton_male.Checked = true;

            textBox_phone.Text = DataGridView_customer.CurrentRow.Cells[6].Value.ToString();
            textBox_email.Text = DataGridView_customer.CurrentRow.Cells[7].Value.ToString();

            // Assuming the value in the 8th column is an Image
            if (DataGridView_customer.CurrentRow.Cells[8].Value != null)
            {
                if (DataGridView_customer.CurrentRow.Cells[8].Value is Image)
                {
                    pictureBox_Customer.Image = (Image)DataGridView_customer.CurrentRow.Cells[8].Value;
                }
                else if (DataGridView_customer.CurrentRow.Cells[8].Value is byte[])
                {
                    byte[] img = (byte[])DataGridView_customer.CurrentRow.Cells[8].Value;
                    MemoryStream ms = new MemoryStream(img);
                    pictureBox_Customer.Image = Image.FromStream(ms);
                }
            }
        }

        private void button_cleard_Click(object sender, EventArgs e)
        {
            textBox_id.Clear();
            textBox_fname.Clear();
            textBox_lname.Clear();
            textBox_phone.Clear();
            textBox_address.Clear();
            textBox_email.Clear();
            radioButton_male.Checked = true;
            dateTimePicker1.Value = DateTime.Now;
            pictureBox_Customer.Image = null;
        }

        private void button_upload_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select photo(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";

            if (opf.ShowDialog() == DialogResult.OK)
                pictureBox_Customer.Image = Image.FromFile(opf.FileName);
        }

        private void button_search1_Click(object sender, EventArgs e)
        {
            DataGridView_customer.DataSource = customer.searchCustomer(textBox_search1.Text);
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)DataGridView_customer.Columns[8];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }
        bool Verify()
        {
            if ((textBox_fname.Text == "") || (textBox_lname.Text == "") ||
                (textBox_phone.Text == "") || (textBox_address.Text == "") ||
                (textBox_email.Text == "") ||
                (pictureBox_Customer.Image == null))


            {
                return false;
            }
            else
                return true;
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            {
                int id = Convert.ToInt32(textBox_id.Text);
                string fname = textBox_fname.Text;
                string lname = textBox_lname.Text;
                string address = textBox_address.Text;
                DateTime birthday = dateTimePicker1.Value;
                string gender = radioButton_male.Checked ? "Male" : "Female";
                string phone = textBox_phone.Text;
                string email = textBox_email.Text;



                int born_year = dateTimePicker1.Value.Year;
                int this_year = DateTime.Now.Year;
                if ((this_year - born_year) < 10 || (this_year - born_year) > 100)
                {
                    MessageBox.Show("The Customer age must be between 10 and 100", "Invalid Birthday", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Verify())
                {
                    try
                    {
                        MemoryStream ms = new MemoryStream();
                        pictureBox_Customer.Image.Save(ms, pictureBox_Customer.Image.RawFormat);
                        byte[] img = ms.ToArray();
                        if (customer.deleteteCustomer(id, fname, lname, address, birthday, gender, phone, email, img))
                        {
                            showTable();
                            MessageBox.Show("Student data Deleted", " Delete Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)

                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Empty Field", "Delete  Customer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
