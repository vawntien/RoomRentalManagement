using AdminApp.model;
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
    public partial class RoomManagement : Form
    {
        DSPhong dsp = new DSPhong();

        void loaddgvphong()
        {
            dgvPhong.DataSource = null;

            dgvPhong.DataSource = dsp.getAllPhong();
        }
        public RoomManagement()
        {
            InitializeComponent();
        }

        #region load anh phong
        
        #endregion

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2GroupBox4_Click(object sender, EventArgs e)
        {

        }

        private void RoomManagement_Load(object sender, EventArgs e)
        {
            
            
            loaddgvphong();
            
        }

        private void dgvPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            string sophopng = "";
            string anhphong = "";
            if (e.RowIndex >= 0)
            {

                DataGridViewRow r = dgvPhong.Rows[e.RowIndex];

                
                string map = r.Cells["MaPhong"].Value.ToString();
                sophopng = map.Last().ToString();
                anhphong= r.Cells["AnhChinh"].Value.ToString();
                //pbPhong.ImageLocation = @"Resources\ImagesRooms\room1\P101_main.jpg";
                pbPhong.ImageLocation = @"Resources\ImagesRooms\room"+sophopng+@"\"+anhphong;
            }
            else
            {
                
            }
        }

        private void pbPhong_Click(object sender, EventArgs e)
        {

        }
    }
}
