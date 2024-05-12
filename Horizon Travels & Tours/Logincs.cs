using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace horizon_travels_and_tours
{
    public partial class Logincs : Form
    {
        CustomerClass customer = new CustomerClass();
        public Logincs()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label8_MouseEnter(object sender, EventArgs e)
        {
            label8.ForeColor = Color.Red;
        }

        private void label8_MouseLeave(object sender, EventArgs e)
        {
            label8.ForeColor = Color.Transparent;
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            if ((textBox_un.Text=="")|| (textBox_p.Text == ""))
            {
                MessageBox.Show("Need Login Data", "Wrong Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

            }
            string uname = textBox_un.Text;
            string pass = textBox_p.Text;
            DataTable table = customer.getList(new MySqlCommand("SELECT * FROM `user` WHERE `UserName`= '" + uname + "' AND `Password`= '" + pass + "'")) ;
           if (table.Rows.Count>0)
            {
                Form1 main = new Form1();
                this.Hide();
                main.Show();
            }
           else
            {
                MessageBox.Show("Your username and password are not exists", "wrong Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
