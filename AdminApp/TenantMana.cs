using AdminApp.model;
using AdminApp.model.MKhach;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminApp
{
    public partial class TenantMana : Form
    {
        DSKhach dsk = new DSKhach();

        void loaddgvKhachThue()
        {
            dgvKhachThue.DataSource = null;

            dgvKhachThue.DataSource = dsk.getAllKhach();
        }
        public TenantMana()
        {
            InitializeComponent();
        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }
        public void StyleDataGrid_KhachHang(DataGridView dgv)
        {
            dgv.BorderStyle = BorderStyle.None;
            dgv.BackgroundColor = Color.White;
            dgv.EnableHeadersVisualStyles = false;
            dgv.AllowUserToAddRows = false;
            dgv.RowHeadersVisible = false;

            // ==== HEADER ====
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 128, 128); // xanh đẹp
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersHeight = 42;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // ==== ROW ====
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 240, 255);
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.RowTemplate.Height = 32;
            dgv.GridColor = Color.FromArgb(220, 220, 220);

            // ==== ZEBRA STRIPING (hàng xen kẽ) ====
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 248, 255);

            // ==== CĂN GIỮA TIÊU ĐỀ ====
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                // căn giữa các cột ID / số
                if (col.Name == "MaKhach" || col.Name == "CCCD" || col.Name == "SoDT")
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            // Border dưới mỗi dòng
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        }


        private void TenantMana_Load(object sender, EventArgs e)
        {
            StyleDataGrid_KhachHang(dgvKhachThue);
            loaddgvKhachThue();
        }

        private void LoadImages()
        {

        }

        private void dgvPhongTroo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel8_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel9_Click(object sender, EventArgs e)
        {

        }

        private void dgvKhachThue_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow r = dgvKhachThue.Rows[e.RowIndex];
            txtMaKhach.Text = r.Cells["MaKhach"].Value.ToString();
            txtTenKhach.Text = r.Cells["HoTen"].Value.ToString();
            txtCCCD.Text = r.Cells["CCCD"].Value.ToString();
            txtSDT.Text = r.Cells["SoDT"].Value.ToString();
            txtEmail.Text = r.Cells["Email"].Value.ToString();
            txtDiaChi.Text = r.Cells["DiaChi"].Value.ToString();
            txtNgaySinh.Text = r.Cells["NgaySinh"].Value.ToString();
            txtNgayTao.Text = r.Cells["NgayTao"].Value.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

}
