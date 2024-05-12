using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace horizon_travels_and_tours
{
    public partial class Form1 : Form
    {
        CustomerClass customer = new CustomerClass();
        packageClass package = new packageClass();
        HotelClass hotel = new HotelClass();




        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            customerCount();
            packageCount();
            hotelCount();
        }

        private void customerCount()
        {
            label_totalCustomers.Text = "Total Customers : " + customer.totalCustomers();

        }
        private void packageCount()
        {
            label_totalPackages.Text = "Total Packages: " + package.totalpackages();
        }
        private void hotelCount()
        {
            label_Hotels.Text = "Total Hotels : " + hotel.totalHotels();
        }
        private void customizeDesign()
        {
            panel_customerSubmenu.Visible = false;
            panel_packagesSubmenu.Visible = false;
            panel_hotelsSubmenu.Visible = false;
            panel_submenutravelling.Visible = false;
        }
        private void hideSubmenu()
        {
            if (panel_customerSubmenu.Visible == true)
                panel_customerSubmenu.Visible = false;
            if (panel_packagesSubmenu.Visible == true)
                panel_packagesSubmenu.Visible = false;
            if (panel_hotelsSubmenu.Visible == true)
                panel_hotelsSubmenu.Visible = false;
            if (panel_submenutravelling.Visible == true)
                panel_submenutravelling.Visible = false;
        }
        private void showSubmenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                hideSubmenu();
                submenu.Visible = true;
            }
            else submenu.Visible = false;
        }

        private void button_customerdetails_Click(object sender, EventArgs e)
        {
            showSubmenu(panel_customerSubmenu);
        }
        #region customerSubmenu
        private void button_addpersonaldetails_Click(object sender, EventArgs e)
        {


            openChildForm(new Addpersonaldetails());
            hideSubmenu();
        }

        private void button_updatepersonaldetails_Click(object sender, EventArgs e)
        {
            openChildForm(new updateCustomerForm());
            hideSubmenu();
        }

        private void button_deletepersonaldetails_Click(object sender, EventArgs e)
        {
            openChildForm(new deleteCustomerdetails());
            hideSubmenu();
        }

        private void button_printcustomerdetails_Click(object sender, EventArgs e)
        {
            openChildForm(new PrintCustomerDetails());
            hideSubmenu();
        }
        #endregion customerSubmenu

        private void button_packages_Click(object sender, EventArgs e)
        {
            showSubmenu(panel_packagesSubmenu);
        }
        #region packagesSubmenu
        private void button_addpackages_Click(object sender, EventArgs e)
        {
            openChildForm(new packagesadd());
            hideSubmenu();
        }

        private void button_bookpackages_Click(object sender, EventArgs e)
        {
            openChildForm(new Bookpackages());
            hideSubmenu();
        }

        private void button_viewpackages_Click(object sender, EventArgs e)
        {
            openChildForm(new Viewpackages());
            hideSubmenu();
        }

        private void button_printpackages_Click(object sender, EventArgs e)
        {
            openChildForm(new Printpackages());
            hideSubmenu();
        }
        #endregion packagesSubmenu



        private Form activeForm = null;
        private void openChildForm(Form ChildForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;
            panel_main.Controls.Add(ChildForm);
            panel_main.Tag = ChildForm;
            ChildForm.BringToFront();
            ChildForm.Show();

        }

        private void button_DashBoard_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            panel_main.Controls.Add(panel_cover);
            customerCount();
            packageCount();
            hotelCount();
        }

        private void button_travellingdetails_Click(object sender, EventArgs e)
        {
            showSubmenu(panel_submenutravelling);
        }
        #region submenutravelling
        private void button_addtravellingdetails_Click(object sender, EventArgs e)
        {
            openChildForm(new travellinginfo());
            hideSubmenu();
        }

        private void button_managetraveelingdetails_Click(object sender, EventArgs e)
        {
            openChildForm(new Managetravelinfo());
            hideSubmenu();
        }

        private void button_printtravelinfo_Click(object sender, EventArgs e)
        {
            openChildForm(new viewtrave());
            hideSubmenu();
        }


        #endregion submenutravelling

        private void button_hotels_Click(object sender, EventArgs e)
        {
            showSubmenu(panel_hotelsSubmenu);
        }

        private void button_addhotels_Click(object sender, EventArgs e)
        {
            openChildForm(new Addhotels());
            hideSubmenu();
        }

        private void button_managehotels_Click(object sender, EventArgs e)
        {
            openChildForm(new ManageHotels());
            hideSubmenu();
        }

        private void button_viewhotel_Click(object sender, EventArgs e)
        {
            openChildForm(new ViewHotel());
            hideSubmenu();
        }

        private void button_bookhotel_Click(object sender, EventArgs e)
        {
            openChildForm(new BookHotel());
            hideSubmenu();
        }

        private void button_payment_Click(object sender, EventArgs e)
        {
            openChildForm(new Paymenthotel());
            hideSubmenu();
        }

        private void button_printbill_Click(object sender, EventArgs e)
        {
            openChildForm(new Printbill());
            hideSubmenu();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openChildForm(new printtaveldetails());
            hideSubmenu();
        }

        private void button_Logout_Click(object sender, EventArgs e)
        {
            Logincs login = new Logincs();
            this.Hide();
            login.Show();
        }
    }
}