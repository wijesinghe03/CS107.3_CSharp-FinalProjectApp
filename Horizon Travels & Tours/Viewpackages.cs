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

namespace horizon_travels_and_tours
{
    public partial class Viewpackages : Form
    {
        private packageClass package = new packageClass();
        public Viewpackages()
        {
            InitializeComponent();
        }

        private void Viewpackages_Load(object sender, EventArgs e)
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

        private void button_searchvp_Click(object sender, EventArgs e)
        {
            DataGridView_package.DataSource = package.searchPackageList(textBox_searchvp.Text);
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)DataGridView_package.Columns[6];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }
    }
}
