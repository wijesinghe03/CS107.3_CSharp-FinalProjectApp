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
    public partial class viewtrave : Form
    {
        TravelClass travel = new TravelClass();
        public viewtrave()
        {
            InitializeComponent();
        }

        private void button_searctiv_Click(object sender, EventArgs e)
        {
            DataGridView_travel.DataSource = travel.searchTravel(textBox_searctiv.Text);
        }

        private void viewtrave_Load(object sender, EventArgs e)
        {
            showTable();
        }
        public void showTable()
        {
            DataGridView_travel.DataSource = travel.getTravelList();


        }
       
    }
}
