using AxWMPLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
            picbxChart.Visible = false;
            pcbCauTruc.Visible = false;
            pcbVew.Visible = false;
            timer1.Start();



            string videoPath = @"Resources\Videos\comethru.wmv";

            string fullPath = System.IO.Path.Combine(Application.StartupPath, videoPath);

            axWindowsMediaPlayer1.URL = fullPath;
            axWindowsMediaPlayer1.uiMode = "none";
            axWindowsMediaPlayer1.settings.setMode("loop", true);
            axWindowsMediaPlayer1.Ctlcontrols.play();
            axWindowsMediaPlayer1.Dock = DockStyle.Fill;
            axWindowsMediaPlayer1.settings.mute = true;

            axWindowsMediaPlayer1.SendToBack();

        }



        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            picbxChart.Visible = true;
            pcbCauTruc.Visible= true;
            pcbVew.Visible= true;
        }

        private void guna2CircleButton2_Click_1(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.mute = !axWindowsMediaPlayer1.settings.mute;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2CircleButton2_Click_2(object sender, EventArgs e)
        {
            string recipient = "someone@example.com";
            string subject = Uri.EscapeDataString("Thông báo từ hệ thống");
            string body = Uri.EscapeDataString("Xin chào,\n\nĐây là nội dung email tự động.");

            string mailto = $"mailto:{recipient}?subject={subject}&body={body}";

            try
            {
                Process.Start(mailto);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể mở ứng dụng mail: " + ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
            lblDate.Text = DateTime.Now.ToString("dddd, dd/MM/yyyy");
        }
    }
}
