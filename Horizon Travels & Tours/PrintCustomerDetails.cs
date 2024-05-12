using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using DGVPrinterHelper;

namespace horizon_travels_and_tours
{
    public partial class PrintCustomerDetails : Form
    {
        CustomerClass customer = new CustomerClass();
        DGVPrinter printer = new DGVPrinter();
        public PrintCustomerDetails()
        {
            InitializeComponent();
        }

        private void PrintCustomerDetails_Load(object sender, EventArgs e)
        {
            showData(new MySqlCommand("SELECT * FROM `customer`;"));
        }
        public void showData(MySqlCommand command) 
        {
            DataGridView_customer.ReadOnly = true;
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            //DataGridView_customer.Height = 80;
            DataGridView_customer.DataSource = customer.getList(command);

            imageColumn = (DataGridViewImageColumn)DataGridView_customer.Columns[8];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
                 
        }

        private void button_searchCD_Click(object sender, EventArgs e)
        {
            string selectQuery;
            if (radioButtonalldetails.Checked)
            {
                selectQuery = "SELECT * FROM `customer`;";
            }
            else if (radioButton_male1.Checked) 
            {
                selectQuery = "SELECT * FROM `customer` WHERE `Gender`= 'Male';";
            }
            else
            {
                selectQuery = "SELECT * FROM `customer` WHERE `Gender`= 'Female';";
            }
            showData(new MySqlCommand(selectQuery));
        }

        private void button_printcustomerdetails_Click(object sender, EventArgs e)
        {
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
            printer.PrintDataGridView(DataGridView_customer);


        }
    }
}
