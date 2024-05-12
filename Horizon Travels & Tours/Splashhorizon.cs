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
    public partial class Splashhorizon : Form
    {
        public Splashhorizon()
        {
            InitializeComponent();
        }

        private void Splashhorizon_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        int starpoint = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            starpoint += 1;
            ProgressIndicator1.Start();
            if (starpoint > 40)
            {
                Logincs login = new Logincs();
                ProgressIndicator1.Stop();
                timer1.Stop();
                this.Hide();
                login.Show();
            }
        }
    }
}
