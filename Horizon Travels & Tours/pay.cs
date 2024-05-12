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
    public partial class pay : Form
    {
        public pay()
        {
            InitializeComponent();
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void guna2CustomCheckBox1_Click(object sender, EventArgs e)
        {
            
                
                if (sender is Guna.UI2.WinForms.Guna2CustomCheckBox clickedCheckbox)
                {
                    foreach (Control control in Controls)
                    {
                        if (control is Guna.UI2.WinForms.Guna2CustomCheckBox checkbox && checkbox != clickedCheckbox)
                        {
                            checkbox.Checked = false;
                        }
                    }
                    clickedCheckbox.Checked = true;
                }
            

        }

        private void guna2CustomCheckBox2_Click(object sender, EventArgs e)
        {
           
            if (sender is Guna.UI2.WinForms.Guna2CustomCheckBox clickedCheckbox)
            {
                foreach (Control control in Controls)
                {
                    if (control is Guna.UI2.WinForms.Guna2CustomCheckBox checkbox && checkbox != clickedCheckbox)
                    {
                        checkbox.Checked = false;
                    }
                }
                clickedCheckbox.Checked = true;
            }

        }

        private void button_complete_Click(object sender, EventArgs e)
        {
            string cardholdername = guna2TextBoxCN.Text;
            string cardnumber = guna2TextBoxCa.Text;
            string mm = guna2TextBoxe1.Text;
            string yyyy = guna2TextBoxe2.Text;
            string c1 = guna2TextBoxc1.Text;
            string c2 = guna2TextBoxc2.Text;
            string c3 = guna2TextBoxc3.Text;
            MessageBox.Show("Payment processed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button_clearpp_Click(object sender, EventArgs e)
        {
            ClearCardDetails();
            MessageBox.Show("Data cleared successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void ClearCardDetails()
        {
            guna2TextBoxCN.Clear();
            guna2TextBoxCa.Clear();
            guna2TextBoxe1.Clear();
            guna2TextBoxe2.Clear();
            guna2TextBoxc1.Clear();
            guna2TextBoxc2.Clear();
            guna2TextBoxc3.Clear();
            
        }
    }
}
