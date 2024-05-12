using DGVPrinterHelper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace horizon_travels_and_tours
{
    public partial class Printpackages : Form
    {
        private packageClass package = new packageClass();
        DGVPrinter printer = new DGVPrinter();
        public Printpackages()
        {
            InitializeComponent();
        }

        private void button_searchpp_Click(object sender, EventArgs e)
        {

            DataGridView_package.DataSource = package.searchPackageList(textBox_searchpp.Text);
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)DataGridView_package.Columns[6];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }

        private void Printpackages_Load(object sender, EventArgs e)
        {
            showData(new MySqlCommand("SELECT * FROM `package`;"));
        }
        public void showData(MySqlCommand command)
        {
            DataGridView_package.ReadOnly = true;
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            DataGridView_package.DataSource = package.getList(command);
            imageColumn = (DataGridViewImageColumn)DataGridView_package.Columns[6];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;

        }

        private void button_printp_Click(object sender, EventArgs e)
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
            printer.PrintDataGridView(DataGridView_package);
        }
    }
}
