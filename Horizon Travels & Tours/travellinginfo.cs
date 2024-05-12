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

namespace horizon_travels_and_tours
{
    public partial class travellinginfo : Form
    {
        TravelClass travel = new TravelClass();
        public travellinginfo()
        {
            InitializeComponent();
        }

        private void button_bookaflight_Click(object sender, EventArgs e)
        {
            addtravelling_detail flight = new addtravelling_detail();
            flight.Show();
            Visible = false;
        }


        private void button_addti_Click(object sender, EventArgs e)
        {
            
            string tcid = textBox_tci.Text;
            string thi = textBox_thi.Text;
            string tpid = textBox_tpi.Text;
            string tfid = textBox_tfi.Text;
            string vn = textBox_tvn.Text;

            if (travel.insetTravel(tcid, thi, tpid, tfid, vn))
            {
                MessageBox.Show("Travel added successfully!", "Add Travel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Optionally clear the textboxes or perform any other actions after successful addition
                showTable();
                ClearTextBoxes();
            }
            else
            {
                MessageBox.Show("Failed to add travel.", "Add Travel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearTextBoxes()
        {
            textBox_tci.Clear();
            textBox_thi.Clear();
            textBox_tpi.Clear();
            textBox_tfi.Clear();
            textBox_tvn.Clear();
        }

        bool verify()
        {
            if ((textBox_tci.Text == "") || (textBox_thi.Text == "") ||
                (textBox_tpi.Text == "") || (textBox_tfi.Text == "") ||
                (textBox_tvn.Text == ""))
            {
                return false;
            }
            else
                return true;
        }

        private void button_clearti_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private void travellinginfo_Load(object sender, EventArgs e)
        {
            showTable();
        }
        public void showTable()
        {
            DataGridView_travel.DataSource = travel.getTravelList();
            

        }

        private void button_searcti_Click(object sender, EventArgs e)
        {
            DataGridView_travel.DataSource = travel.searchTravel(textBox_searcti.Text);
        }
    }
}
