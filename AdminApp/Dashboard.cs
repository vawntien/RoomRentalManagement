using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminApp
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

            string videoPath = @"Resources\Videos\comethru.wmv";


            string fullPath = System.IO.Path.Combine(Application.StartupPath, videoPath);

            axWindowsMediaPlayer1.URL = fullPath;
            axWindowsMediaPlayer1.uiMode = "full";
            // Tự động phát video
            axWindowsMediaPlayer1.Ctlcontrols.play();





        }
    }
}
