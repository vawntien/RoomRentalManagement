using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminApp
{
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(guna2CircleProgressBar1.Value == 100)
            {
                timer1.Stop();
                //this.Hide();
                //Login loginForm = new Login();
                //loginForm.Show();
            }
            else
            {
                guna2CircleProgressBar1.Value += 1;
                lblTimer.Text = (Convert.ToInt32(lblTimer.Text) + 1).ToString();
            }

                

        }

        private void guna2CircleProgressBar1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Loading_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
            timer1.Start();
        }
    }
}
