using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;


namespace horizon_travels_and_tours
{
    public partial class Printbill : Form
    {
        BillClass1 bill = new BillClass1();

        public Printbill()
        {
            InitializeComponent();
        }

        private void Printbill_Load(object sender, EventArgs e)
        {

        }
        bool verify()
        {
            if ((textBox_cidp.Text == "") || (textBox_pidp.Text == "") ||
             (textBox_hidp.Text == "") || (textBox_cp.Text == "") ||
             (textBox_tp.Text == "") ||
             (textBox_sp.Text == ""))
            {
                return false;
            }
            else
                return true;
        }

        private void button_addbill_Click(object sender, EventArgs e)
        {
            
                if (!verify())
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }

                try
                {
                    string cuid = textBox_cidp.Text;
                    string paid = textBox_pidp.Text;
                    string hoid = textBox_hidp.Text;
                    string country = textBox_cp.Text;
                    string total = textBox_tp.Text;
                    DateTime date = dateTimePicker1p.Value;
                    string signature = textBox_sp.Text;

                    if (bill.insertforbill(cuid, paid, hoid, country, total, date, signature))
                    {
                        MessageBox.Show("Bill added successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Failed to add bill.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }

        

        private void button_printbi_Click(object sender, EventArgs e)
        {

            Billingdatatable bill = new Billingdatatable();
            bill.Show();
            Visible = false;
        }

        private void button_clearbillp_Click(object sender, EventArgs e)
        {
            textBox_cidp.Clear();
            textBox_pidp.Clear();
            textBox_hidp.Clear();
            textBox_cp.Clear();
            textBox_tp.Clear();
            dateTimePicker1p.Value = DateTime.Now;
            textBox_sp.Clear();
        }
    }
}