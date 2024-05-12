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
    public partial class Managetravelinfo : Form
    {
        TravelClass travel = new TravelClass();
        public Managetravelinfo()
        {
            InitializeComponent();
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
        private void ClearTextBoxes()
        {
            textBox_tci.Clear();
            textBox_thi.Clear();
            textBox_tpi.Clear();
            textBox_tfi.Clear();
            textBox_tvn.Clear();
        }

        private void button_updatetm_Click(object sender, EventArgs e)
        {
           
                string tid = textBox_tid.Text;
                string tcid = textBox_tci.Text;
                string thi = textBox_thi.Text;
                string tpid = textBox_tpi.Text;
                string tfid = textBox_tfi.Text;
                string vn = textBox_tvn.Text;

                if (int.TryParse(tid, out int travelId)) // Convert tid to integer
                {
                    if (travel.updateTravel(travelId, tcid, thi, tpid, tfid, vn)) // Pass travelId instead of tid
                    {
                        MessageBox.Show("Travel Updated successfully!", "Update Travel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Optionally clear the textboxes or perform any other actions after successful addition
                        showTable();
                        ClearTextBoxes();
                    }
                    else
                    {
                        MessageBox.Show("Failed to Update travel.", "Update Travel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Travel ID.", "Update Travel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            

        }

        private void button_deletetm_Click(object sender, EventArgs e)
        {
            
                string tid = textBox_tid.Text;
                string tcid = textBox_tci.Text;
                string thi = textBox_thi.Text;
                string tpid = textBox_tpi.Text;
                string tfid = textBox_tfi.Text;
                string vn = textBox_tvn.Text;

                if (int.TryParse(tid, out int travelId)) // Convert tid to integer
                {
                    if (travel.deleteTravel(travelId, tcid, thi, tpid, tfid, vn)) // Pass travelId instead of tid
                    {
                        MessageBox.Show("Travel Deleted successfully!", "Delete Travel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Optionally clear the textboxes or perform any other actions after successful addition
                        showTable();
                        ClearTextBoxes();
                    }
                    else
                    {
                        MessageBox.Show("Failed to Delete travel.", "Delete Travel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Travel ID.", "Delete Travel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            

        }

        private void button_cleartm_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private void Managetravelinfo_Load(object sender, EventArgs e)
        {
            showTable();
        }
        public void showTable()
        {
            DataGridView_travel.DataSource = travel.getTravelList();


        }

        private void DataGridView_travel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_tid.Text = DataGridView_travel.CurrentRow.Cells[0].Value.ToString();
            textBox_tci.Text = DataGridView_travel.CurrentRow.Cells[1].Value.ToString();
            textBox_thi.Text = DataGridView_travel.CurrentRow.Cells[2].Value.ToString();
            textBox_tpi.Text = DataGridView_travel.CurrentRow.Cells[3].Value.ToString();
            textBox_tfi.Text = DataGridView_travel.CurrentRow.Cells[4].Value.ToString();
            textBox_tvn.Text = DataGridView_travel.CurrentRow.Cells[5].Value.ToString();

        }

        private void button_searctm_Click(object sender, EventArgs e)
        {
            DataGridView_travel.DataSource = travel.searchTravel(textBox_searctm.Text);
        }
    }
}
