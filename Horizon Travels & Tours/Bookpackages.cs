using System;
using System.Data;
using System.Windows.Forms;

namespace horizon_travels_and_tours
{
    public partial class Bookpackages : Form
    {
        private packageClass package = new packageClass();

        public Bookpackages()
        {
            InitializeComponent();
        }

        private void Bookpackages_Load(object sender, EventArgs e)
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
            
            int bookButtonColumnIndex = 7; 

            if (e.ColumnIndex == bookButtonColumnIndex && e.RowIndex >= 0)
            {
                

                int packageId = Convert.ToInt32(DataGridView_package.Rows[e.RowIndex].Cells["PackageId"].Value);

                

                if (package.bookpackage(packageId))
                {
                    MessageBox.Show("Package booked successfully!", "Book Package", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showTable(); 

                }
                else
                {
                    MessageBox.Show("Failed to book package.", "Book Package", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button_searchpb_Click(object sender, EventArgs e)
        {
            DataGridView_package.DataSource = package.searchPackageList(textBox_searchpb.Text);
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)DataGridView_package.Columns[6];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }

        private void button_book_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox_pid.Text))
            {
                int packageId;
                if (!int.TryParse(textBox_pid.Text, out packageId))
                {
                    MessageBox.Show("Invalid package ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                MessageBox.Show("Package ID: " + packageId, "Debug", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (package.bookpackage(packageId))
                {
                    MessageBox.Show("Package booked successfully!", "Book Package", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showTable(); 

                }
                else
                {
                    MessageBox.Show("Failed to book package.", "Book Package", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter a package ID to book.", "Book Package", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
