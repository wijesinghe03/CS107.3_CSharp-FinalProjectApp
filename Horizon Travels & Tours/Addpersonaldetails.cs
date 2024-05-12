using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Guna.UI2.WinForms.Enums;

namespace horizon_travels_and_tours
{
    public partial class Addpersonaldetails : Form
    {
        CustomerClass customer = new CustomerClass();
        public Addpersonaldetails()
        {
            InitializeComponent();
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

       

        private void Addpersonaldetails_Load(object sender, EventArgs e)
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

        private void button_upload_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select photo(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";

            if (opf.ShowDialog() == DialogResult.OK)
                pictureBox_Customer.Image = Image.FromFile(opf.FileName);
        }

        private void button_add_Click(object sender, EventArgs e)
        {
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
                    if (customer.insertCustomer(fname, lname, address, birthday, gender, phone, email, img))
                    {
                        showTable();
                        MessageBox.Show("New Customer Details Added!", "Add Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)

                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Empty Field", "Add Customer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            textBox_fname.Clear();
            textBox_lname.Clear();
            textBox_phone.Clear();
            textBox_address.Clear();
            textBox_email.Clear();
            radioButton_male.Checked = true;
            dateTimePicker1.Value = DateTime.Now;
            pictureBox_Customer.Image = null;
        }

        
    }
}
