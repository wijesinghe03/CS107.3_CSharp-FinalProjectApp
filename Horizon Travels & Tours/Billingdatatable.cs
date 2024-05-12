
using DGVPrinterHelper;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace horizon_travels_and_tours
{
    public partial class Billingdatatable : Form
    {
        private readonly BillClass1 bill = new BillClass1();
        private readonly DGVPrinter printer = new DGVPrinter();

        public Billingdatatable()
        {
            InitializeComponent();
        }

        private void Billingdatatable_Load(object sender, EventArgs e)
        {
            showData(new MySqlCommand("SELECT * FROM `forbill`"));
        }

        public void showData(MySqlCommand command)
        {
            DataGridView_bill.ReadOnly = true;
            DataGridView_bill.DataSource = bill.getList(command);
        }

        private void button_searchbill_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox_searchbill.Text))
            {
                DataGridView_bill.DataSource = bill.searchBill(textBox_searchbill.Text);
            }
            else
            {
                MessageBox.Show("Please enter a search query.", "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_print_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox_bid.Text) && int.TryParse(textBox_bid.Text, out int BillingId))
            {
                MessageBox.Show("Billing ID: " + BillingId, "Debug", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DataTable billDetails = bill.getBillDetails(BillingId);
                if (billDetails.Rows.Count > 0)
                {
                    MessageBox.Show("Bill printed successfully!", "Print Bill", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    printer.Title = "Horizon Tours and Travels List";
                    printer.SubTitle = string.Format("Data: {0}", DateTime.Now.Date);
                    printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                    printer.PageNumbers = true;
                    printer.PageNumberInHeader = false;
                    printer.PorportionalColumns = true;
                    printer.HeaderCellAlignment = StringAlignment.Near;
                    printer.Footer = "Horizon";
                    printer.FooterSpacing = 15;
                    printer.printDocument.DefaultPageSettings.Landscape = true;
                    printer.PrintDataGridView(DataGridView_bill);
                }
                else
                {
                    MessageBox.Show("No details found for the entered Bill ID.", "Print Bill", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid Bill ID to print.", "Print Bill", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox_bid_TextChanged(object sender, EventArgs e)
        {

            button_print.Enabled = int.TryParse(textBox_bid.Text, out _);
        }
    }
}