using AdminApp.model;
using AdminApp.model.MNguoiDung;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminApp
{
    public partial class UserManagement : Form
    {
        DSNguoiDung dsn = new DSNguoiDung();
        public UserManagement()
        {
            InitializeComponent();
        }

        void loaddgvNguoiDung_By_Name(string name)
        {
            StyleDataGridView(dgvNguoiDung);


            dgvNguoiDung.DataSource = null;
            dgvNguoiDung.DataSource = dsn.getNguoiDung_By_Name(name);
            dgvNguoiDung.Columns["TaiKhoan"].HeaderText = "Tài khoản";
            dgvNguoiDung.Columns["MatKhau"].HeaderText = "Mật khẩu";
            dgvNguoiDung.Columns["VaiTro"].HeaderText = "Vai trò";
            dgvNguoiDung.Columns["MaKhach"].HeaderText = "Mã khách";
            dgvNguoiDung.Columns["Email"].HeaderText = "Email";
            dgvNguoiDung.Columns["TrangThai"].HeaderText = "Trạng thái tài khoản";
            dgvNguoiDung.Columns["NgayDangKy"].HeaderText = "Ngày đăng ký";


            dgvNguoiDung.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        void loaddgvNguoiDung()
        {
            StyleDataGridView(dgvNguoiDung);


            dgvNguoiDung.DataSource = null;
            dgvNguoiDung.DataSource = dsn.getAllNguoiDung();
            dgvNguoiDung.Columns["TaiKhoan"].HeaderText = "Tài khoản";
            dgvNguoiDung.Columns["MatKhau"].HeaderText = "Mật khẩu";
            dgvNguoiDung.Columns["VaiTro"].HeaderText = "Vai trò";
            dgvNguoiDung.Columns["MaKhach"].HeaderText = "Mã khách";
            dgvNguoiDung.Columns["Email"].HeaderText = "Email";
            dgvNguoiDung.Columns["TrangThai"].HeaderText = "Trạng thái tài khoản";
            dgvNguoiDung.Columns["NgayDangKy"].HeaderText = "Ngày đăng ký";


            dgvNguoiDung.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        void loadfirst()
        {
            txtTaiKhoan.Enabled=false;
            txtMatKhau.Enabled = false;
            txtVaiTro.Enabled = false;
            txtEmail.Enabled = false;
            rdHoatDong.Enabled = false;
            rdKhoa.Enabled = false;
            rdKhongHD.Enabled = false;
            txtMaKhach.Enabled = false;
            txtNgayDangKy.Enabled = false;

            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnChinhSua.Enabled = false;
            btn_SaveChange.Enabled = false;
        }

        private void StyleDataGridView(DataGridView dgv)
        {
            dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgv.BackgroundColor = Color.White;
            dgv.EnableHeadersVisualStyles = false;
            dgv.AllowUserToAddRows = false;
            dgv.RowHeadersVisible = false;

            // -------------------------
            // HEADER
            // -------------------------
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 128, 128); // DodgerBlue
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersHeight = 40;

            // -------------------------
            // ROW STYLE
            // -------------------------
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 240, 255);
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.RowTemplate.Height = 35;

            // -------------------------
            // GRID LINES
            // -------------------------
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.GridColor = Color.LightGray;

            // Tự động fill toàn bộ chiều rộng
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void UserManagement_Load(object sender, EventArgs e)
        {
            loadfirst();
            loaddgvNguoiDung();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dgvNguoiDung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow r = dgvNguoiDung.Rows[e.RowIndex];
            txtTaiKhoan.Text = r.Cells["TaiKhoan"].Value.ToString();
            txtMatKhau.Text= r.Cells["MatKhau"].Value.ToString();
            txtEmail.Text = r.Cells["Email"].Value.ToString();
            txtMaKhach.Text = r.Cells["MaKhach"].Value.ToString();
            txtVaiTro.Text = r.Cells["VaiTro"].Value.ToString();
            txtNgayDangKy.Text = r.Cells["NgayDangKy"].Value.ToString();

            btnChinhSua.Enabled = true;
            btnXoa.Enabled = true;

            if (r.Cells["TrangThai"].Value.ToString() == "Hoạt động")
            {
                rdHoatDong.Checked = true;
            }
            else if (r.Cells["TrangThai"].Value.ToString() == "Khóa")
            {
                rdKhoa.Checked = true;
            }
            else
            {
                rdKhongHD.Checked = true;
            }
        }

        private void dgvNguoiDung_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            txtTaiKhoan.Enabled = false;
            txtMatKhau.Enabled = true;
            txtVaiTro.Enabled = true; 
            txtEmail.Enabled = true;
            rdHoatDong.Enabled = true;
            rdKhoa.Enabled = true;
            rdKhongHD.Enabled = true; 
            txtMaKhach.Enabled = true;
            txtNgayDangKy.Enabled = true; 

            btn_SaveChange.Enabled = true;
            btnLuu.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(btnThem.Enabled == true && btnLuu.Enabled==true)
            {
                NguoiDung nd = new NguoiDung();
                nd.TaiKhoan = txtTaiKhoan.Text;
                nd.MatKhau = txtMatKhau.Text;
                nd.VaiTro = txtVaiTro.Text;
                
                if (nd.VaiTro.ToLower() != "admin" && nd.VaiTro.ToLower() != "user")
                {
                    MessageBox.Show("Vai tro khong hop le chi admin hoac user");
                    return;
                }    
                nd.Email = txtEmail.Text;
                //nd.MaKhach = int.Parse(txtMaKhach.Text);
                nd.NgayDangKy = txtNgayDangKy.Text;
                nd.TrangThai = "Chưa hoạt động";
                if (dsn.addNguoiDung(nd))
                {
                    MessageBox.Show("Thêm người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loaddgvNguoiDung();
                    loadfirst();
                    return;
                }
                else
                {
                    MessageBox.Show("Thêm người dùng thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (txtTaiKhoan.Text == "" || txtMatKhau.Text == "" || txtVaiTro.Text == "" || txtEmail.Text == "" || txtMaKhach.Text == "" || txtNgayDangKy.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(rdHoatDong.Checked == false && rdKhoa.Checked == false && rdKhongHD.Checked == false)
            {
                MessageBox.Show("Vui lòng chọn trạng thái tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(btnChinhSua.Enabled == true && btnLuu.Enabled==true)
            {
                NguoiDung nd = new NguoiDung();
                nd.TaiKhoan = txtTaiKhoan.Text;
                nd.MatKhau = txtMatKhau.Text;
                nd.VaiTro = txtVaiTro.Text;
                nd.Email = txtEmail.Text;
                nd.MaKhach = int.Parse( txtMaKhach.Text);
                nd.NgayDangKy = txtNgayDangKy.Text;
                if (rdHoatDong.Checked == true)
                {
                    nd.TrangThai = "Hoạt động";
                }
                else if (rdKhoa.Checked == true)
                {
                    nd.TrangThai = "Khóa";
                }
                else
                {
                    nd.TrangThai = "Chưa hoạt động";
                }
                // Cập nhật người dùng vào database
                bool success = dsn.updateNGUOIDUNG(nd);
                if (success)
                {
                    MessageBox.Show("Cập nhật người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loaddgvNguoiDung();
                    loadfirst();
                }
                else
                {
                    MessageBox.Show("Cập nhật người dùng thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(dsn.deleteNGUOIDUNG(txtTaiKhoan.Text))
            {
                MessageBox.Show("Xóa người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loaddgvNguoiDung();
                loadfirst();
            }
            else
            {
                MessageBox.Show("Xóa người dùng thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            btnChinhSua.Enabled = false;
            btnXoa.Enabled = false;

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtTaiKhoan.Enabled = true;
            txtMatKhau.Enabled = true;
            txtVaiTro.Enabled = true;
            txtEmail.Enabled = true;
            rdHoatDong.Enabled = true;
            rdKhoa.Enabled = true;
            rdKhongHD.Enabled = true;
            txtMaKhach.Enabled = true;
            txtNgayDangKy.Enabled = true;
            btnLuu.Enabled = true;
            
            
        }

        private void btn_Search_User_Click(object sender, EventArgs e)
        {
            string nameUser = txt_User.Text;
            if (!string.IsNullOrEmpty(nameUser))
            {
                loaddgvNguoiDung_By_Name(nameUser);
            }
            else
                MessageBox.Show("Nhap ten nguoi dung can tim");
        }

        private void btn_Refresh_User_Click(object sender, EventArgs e)
        {
            loaddgvNguoiDung();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btn_SaveChange_Click(object sender, EventArgs e)
        {
            string tk = txtTaiKhoan.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(ConnectionModel.execNguoiDung, ConnectionModel.strcnn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

            DataSet ds = new DataSet();

            adapter.Fill(ds, "NGUOIDUNG");

            if (txtTaiKhoan.Text == "" || txtMatKhau.Text == "" || txtVaiTro.Text == "" || txtEmail.Text == "" || txtMaKhach.Text == "" || txtNgayDangKy.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (rdHoatDong.Checked == false && rdKhoa.Checked == false && rdKhongHD.Checked == false)
            {
                MessageBox.Show("Vui lòng chọn trạng thái tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtVaiTro.Text.ToLower() != "admin" && txtVaiTro.Text.ToLower() != "user")
            {
                MessageBox.Show("Vai tro khong hop le chi admin hoac user");
                return;
            }

            foreach (DataRow row in ds.Tables["NGUOIDUNG"].Rows)
            {
                if (row["TaiKhoan"].ToString() == tk)
                {
                    row["MatKhau"] = txtMatKhau.Text;
                    row["VaiTro"] = txtVaiTro.Text;
                    row["Email"] = txtEmail.Text;
                    row["NgayDangKy"] = DateTime.Parse(txtNgayDangKy.Text); 


                    adapter.Update(ds, "NGUOIDUNG");
                    loaddgvNguoiDung();
                    MessageBox.Show("Thay doi thong tin thanh cong");
                    return;
                }
            }
            
        }
    }
}
