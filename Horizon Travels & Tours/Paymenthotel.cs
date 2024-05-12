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
    public partial class Paymenthotel : Form
    {
        private HotelClass hotel = new HotelClass();
        private DataTable dataTable;
        public Paymenthotel()
        {
            InitializeComponent();
        }

        private void Paymenthotel_Load(object sender, EventArgs e)
        {
            showTable();
        }
        private void showTable()
        {
            DataGridView_hotel.DataSource = hotel.getHotelList();
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)DataGridView_hotel.Columns[8];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }

        private void DataGridView_hotel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
        }

        private void button_searchhp_Click(object sender, EventArgs e)
        {
            string searchData = textBox_searchhp.Text.Trim();
            if (!string.IsNullOrEmpty(searchData))
            {
                DataTable searchResult = hotel.searchHotels(searchData);
                if (searchResult.Rows.Count > 0)
                {
                    DataGridView_hotel.DataSource = searchResult;
                    DataGridViewImageColumn imageColumn = (DataGridViewImageColumn)DataGridView_hotel.Columns["Image"];
                    imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
                }
                else
                {
                    MessageBox.Show("No hotels found.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                showTable();
            }

        }

        private void button_pay_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(textBox_hid.Text))
            {
                int hotelId;
                if (int.TryParse(textBox_hid.Text, out hotelId))
                {
                    bool booked = hotel.bookhotel(hotelId);
                    if (booked)
                    {
                        MessageBox.Show("Hotel booked successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Check if "Yes" radio button is checked
                        if (radioButtonp1.Checked)
                        {
                            // Open payment form only if "Yes" is checked
                            pay payment = new pay();
                            payment.Show();
                            Visible = false;
                        }
                        else
                        {
                            // Display message if "No" is checked
                            MessageBox.Show("Payment not processed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Failed to process payment because hotel id was incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid hotel ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter a hotel ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    }

