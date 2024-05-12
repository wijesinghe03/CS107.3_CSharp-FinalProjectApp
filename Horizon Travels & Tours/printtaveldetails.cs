using DGVPrinterHelper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace horizon_travels_and_tours
{
    public partial class printtaveldetails : Form
    {
        TravelClass travel = new TravelClass();
        private readonly DGVPrinter printer = new DGVPrinter();


        public printtaveldetails()
        {
            InitializeComponent();
        }

        private void printtaveldetails_Load(object sender, EventArgs e)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `travel`");
            showData(command);
        }
        public void showData(MySqlCommand command)
        {
            DataGridView_travel.ReadOnly = true;
            DataGridView_travel.DataSource = travel.getList(command);
        }


        private void button_searctp_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox_searctp.Text))
            {
                DataGridView_travel.DataSource = travel.searchTravel(textBox_searctp.Text);
            }
            else
            {
                MessageBox.Show("Please enter a search query.", "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void button_printtavel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox_tid.Text) && int.TryParse(textBox_tid.Text, out int TravelId))
            {
                MessageBox.Show("Travel ID: " + TravelId, "Debug", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DataTable TravelDetails = travel.getTravelDetails(TravelId);
                if (TravelDetails.Rows.Count > 0)
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
                    printer.PrintDataGridView(DataGridView_travel);
                }
                else
                {
                    MessageBox.Show("No details found for the entered Travel ID.", "Print Travel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid Travel ID to print.", "Print Travel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
