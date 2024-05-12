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
using System.Diagnostics;
using horizon_travels_and_tours;

namespace horizon_travels_and_tours
{
    public partial class addtravelling_detail : Form
    {
        FlightClass flight = new FlightClass();
        public addtravelling_detail()
        {
            InitializeComponent();
        }

        private void addtravelling_detail_Load(object sender, EventArgs e)
        {
            showTable();
        }
        public void showTable()
        {
            DataGridView_flight.ReadOnly = true;
            DataGridView_flight.DataSource = flight.getFlightList();
        }

        bool verify()
        {
            if ((textBox_from.Text == "") || (textBox_to.Text == "") ||
                (textBox_airline.Text == "") || (textBox_phonet.Text == ""))
            {
                return false;
            }
            else
                return true;
        }

        private void button_bookt_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(textBox_fid.Text))
            {
                int FlightId;
                if (!int.TryParse(textBox_fid.Text, out FlightId))
                {
                    MessageBox.Show("Invalid flight ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Flight ID: " + FlightId, "Debug", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (flight.bookFlight(FlightId))
                {
                    MessageBox.Show("Flight booked successfully!", "Book Flight", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showTable();
                }
                else
                {
                    MessageBox.Show("Failed to book flight.", "Book Flight", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter a flight ID to book.", "Book Flight", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClearTextBoxes()
        {
            radioButton_round.Checked = true;
            textBox_from.Clear();
            textBox_to.Clear();
            textBox_phonet.Clear();
            dateTimePicker1t.Value = DateTime.Now;
            dateTimePicker2t.Value = DateTime.Now;
        }








        private void button_cleart_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private void button_addf_Click(object sender, EventArgs e)
        {
            string triptype = radioButton_round.Checked ? "RoundTrip" : "OneWayTrip";
            string from = textBox_from.Text;
            string to = textBox_to.Text;
            string airline = textBox_airline.Text;
            string phone = textBox_phonet.Text;
            DateTime depature = dateTimePicker1t.Value;
            DateTime ret = dateTimePicker2t.Value;
            
            if (flight.insetFlight(triptype, from, to, airline, phone, depature, ret))
            {
                MessageBox.Show("Flight Details Added successfully!", "Add Flight", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showTable(); // Refresh the DataGridView after adding
                ClearTextBoxes();
            }
            else
            {
                MessageBox.Show("Failed to Add Flight Details.", "AddTravel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_flight_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DataGridView_flight.Columns["Book"].Index && e.RowIndex >= 0)
            {
                int flightId = Convert.ToInt32(DataGridView_flight.Rows[e.RowIndex].Cells["FlightId"].Value);

                if (flight.bookFlight(flightId))
                {
                    MessageBox.Show("Flight booked successfully!", "Book Flight", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showTable(); // Refresh DataGridView after booking
                }
                else
                {
                    MessageBox.Show("Failed to book flight.", "Book Flight", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
