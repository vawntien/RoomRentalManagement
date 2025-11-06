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

        #region methods hide show everythings
        void hidetext()
        {
            txtMaPhong.Visible = false;
            txtTenPhong.Visible = false;
            txtGiaPhong.Visible = false;
            txtNoiThat.Visible = false;
            txtDienTich.Visible = false;
            txtTinhTrang.Visible = false;
            txtSoNguoiToiDa.Visible = false;
            txtMoTa.Visible = false;

        }
        void showtext()
        {
            txtMaPhong.Visible = true;
            txtTenPhong.Visible = true;
            txtGiaPhong.Visible = true;
            txtNoiThat.Visible = true;
            txtDienTich.Visible = true;
            txtTinhTrang.Visible = true;
            txtSoNguoiToiDa.Visible = true;
            txtMoTa.Visible = true;
        }
        void show_bordertext()
        {

            txtMaPhong.BorderColor = Color.Silver;
            txtTenPhong.BorderColor = Color.Silver;
            txtGiaPhong.BorderColor = Color.Silver;
            txtNoiThat.BorderColor = Color.Silver;
            txtDienTich.BorderColor = Color.Silver;
            txtTinhTrang.BorderColor = Color.Silver;
            txtSoNguoiToiDa.BorderColor = Color.Silver;
            txtMoTa.BorderColor = Color.Silver;
        }
        void hide_bordertext()
        {
            txtMaPhong.BorderColor = Color.White;
            txtTenPhong.BorderColor = Color.White;
            txtGiaPhong.BorderColor = Color.White;
            txtNoiThat.BorderColor = Color.White;
            txtDienTich.BorderColor = Color.White;
            txtTinhTrang.BorderColor = Color.White;
            txtSoNguoiToiDa.BorderColor = Color.White;
            txtMoTa.BorderColor = Color.White;
        }

        void txtReadOnly()
        {
            txtMaPhong.ReadOnly = true;
            txtTenPhong.ReadOnly = true;
            txtGiaPhong.ReadOnly = true;
            txtNoiThat.ReadOnly = true;
            txtDienTich.ReadOnly = true;
            txtTinhTrang.ReadOnly = true;
            txtSoNguoiToiDa.ReadOnly = true;
            txtMoTa.ReadOnly = true;
        }

        void txtNonRdonly()
        {
            txtMaPhong.ReadOnly = false;
            txtTenPhong.ReadOnly = false;
            txtGiaPhong.ReadOnly = false;
            txtNoiThat.ReadOnly = false;
            txtDienTich.ReadOnly = false;
            txtTinhTrang.ReadOnly = false;
            txtSoNguoiToiDa.ReadOnly = false;
            txtMoTa.ReadOnly = false;

            
        }

        void hidelbl()
        {
            lblMPhong.Visible = false;
            lblTenPhong.Visible = false;
            lblGiaPhong.Visible = false;
            lblNoiThat.Visible = false;
            lblDienTich.Visible = false;
            lblTinhTrang.Visible = false;
            lblSoNguoiToiDa.Visible = false;
            lblMoTa.Visible = false;
        }

        void showlbl()
        {
            lblMPhong.Visible = true;
            lblTenPhong.Visible = true;
            lblGiaPhong.Visible = true;
            lblNoiThat.Visible = true;
            lblDienTich.Visible = true;
            lblTinhTrang.Visible = true;
            lblSoNguoiToiDa.Visible = true;
            lblMoTa.Visible = true;
        }

        void hideimagebtn()
        {
            imgbtnFI1.Visible = false;
            imgbtnFI2.Visible = false;
            imgbtnFI3.Visible = false;
            imgbtnFI4.Visible = false;
        }
        #endregion


        void loaddgvphong()
        {
            dgvPhong.DataSource = null;

            dgvPhong.DataSource = dsp.getAllPhong();
        }
        public RoomManagement()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            show_bordertext();
            txtNonRdonly();
        }

        private void guna2GroupBox4_Click(object sender, EventArgs e)
        {

        }

        

        void loadthings()
        {
            hidelbl();
            hidetext();
            hide_bordertext();
            hideimagebtn();
        }

        private void RoomManagement_Load(object sender, EventArgs e)
        {
            loaddgvphong();

            loadthings();
            
        }

        private void dgvPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            string sophopng = "";
            string anhphong = "";
            if (e.RowIndex >= 0)
            {

                DataGridViewRow r = dgvPhong.Rows[e.RowIndex];

                showtext();
                hide_bordertext();
                showlbl();
                txtReadOnly();
                string map = r.Cells["MaPhong"].Value.ToString();
                sophopng = map.Last().ToString();
                anhphong= r.Cells["AnhChinh"].Value.ToString();
                //pbPhong.ImageLocation = @"Resources\ImagesRooms\room1\P101_main.jpg";
                
                grbRoom.Text = "Room " + sophopng;

                txtMaPhong.Text = map;

                txtTenPhong.Text = r.Cells["TenPhong"].Value.ToString();
                txtGiaPhong.Text= r.Cells["GiaPhong"].Value.ToString();
                txtNoiThat.Text= r.Cells["NoiThat"].Value.ToString();
                txtDienTich.Text= r.Cells["DienTich"].Value.ToString();
                txtTinhTrang.Text= r.Cells["TinhTrang"].Value.ToString();
                txtSoNguoiToiDa.Text= r.Cells["SoNguoiToiDa"].Value.ToString();
                txtMoTa.Text= r.Cells["MoTaChiTiet"].Value.ToString();

                pbPhong.ImageLocation = @"Resources\ImagesRooms\room"+sophopng+@"\"+anhphong;
            }
            else
            {
                
            }
        }

        private void pbPhong_Click(object sender, EventArgs e)
        {

        }

        private void grbRoom_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void btnThemPhong_Click(object sender, EventArgs e)
        {

        }

        private void btnThemPhong_Click_1(object sender, EventArgs e)
        {

        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {

        }

        private void dgvPhong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
