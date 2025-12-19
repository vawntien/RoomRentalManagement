using AdminApp.model;
using AdminApp.model.MKhach;
using AdminApp.model.MNguoiDung;
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
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Dashboard Overview";
            picboxTitle.Image = Properties.Resources.aaaaa;
            
            //string gifPath = Path.Combine(Application.StartupPath, "Resources", "gifs", "title1.gif");
            //if (File.Exists(gifPath))
            //{
            //    picboxTitle.Image = Image.FromFile(gifPath);
            //    picboxTitle.SizeMode = PictureBoxSizeMode.StretchImage;
            //}




            container(new Dashboard());


        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Principal_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);

            


        }

        void container(object _form)
        {
            if (panContainer.Controls.Count > 0)
            {
                panContainer.Controls.Clear();
            }
            Form fm = _form as Form;
            fm.TopLevel = false;
            fm.FormBorderStyle = FormBorderStyle.None;
            fm.Dock = DockStyle.Fill;
            panContainer.Controls.Add(fm);
            panContainer.Tag = fm;
            fm.Show();
        }

        private void panContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Danh sach phong";
            picboxTitle.Image = Properties.Resources.aaaaa;

            //string gifPath = Path.Combine(Application.StartupPath, "Resources", "gifs", "title1.gif");
            //if (File.Exists(gifPath))
            //{
            //    picboxTitle.Image = Image.FromFile(gifPath);
            //    picboxTitle.SizeMode = PictureBoxSizeMode.StretchImage;
            //}


            container(new RoomManagement());
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Danh sach phong";
            picboxTitle.Image = Properties.Resources.aaaaa;
            container(new ContactMana());
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Danh sach khach hang";
            picboxTitle.Image = Properties.Resources.aaaaa;
            //container(new TenantMana());
            TenantMana tenantMana = new TenantMana();
            container(tenantMana);

            
        }

        private void panLeft_Paint(object sender, PaintEventArgs e)
        {

        }

        private void picboxTitle_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Danh sach nguoi dung";
            picboxTitle.Image = Properties.Resources.aaaaa;
            container(new UserManagement());
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        

        private void panTop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSwap_Click(object sender, EventArgs e)
        {
            //string gifPath1 = Path.Combine(Application.StartupPath, "Resources", "gifs", "fire.gif");
            //if (File.Exists(gifPath1))
            //{
            //    pictureChill2.Image = Image.FromFile(gifPath1);
            //    pictureChill2.SizeMode = PictureBoxSizeMode.StretchImage;
            //}


            loadgif(picback, "back1.gif");
            loadgif(pictureChill2, "fire.gif");
            loadgif(pictureChill1, "chill.gif");



        }

        void loadgif(PictureBox p, string name)
        {
            string gifPath1 = Path.Combine(Application.StartupPath, "Resources", "gifs", name);
            if (File.Exists(gifPath1))
            {
                p.Image = Image.FromFile(gifPath1);
                p.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            DSPhong dsp = new DSPhong();
            DSKhach dsk = new DSKhach();
            DSNguoiDung dsn = new DSNguoiDung();

            List<Phong> listPhong = dsp.getAllPhong();
            List<Khach> lstk = dsk.getAllKhach();
            List<Phong> room = new List<Phong>();
            List<NguoiDung> lstnd = dsn.getAllNguoiDung();


            foreach (var item in listPhong)
            {
                if (txtFind.Text != null)
                {
                    if (item.MaPhong.ToString().Contains(txtFind.Text) || item.TenPhong.ToString().Contains(txtFind.Text))
                    {
                        MessageBox.Show("Tìm thấy phòng: " + item.TenPhong + "Trạng thái phòng: " + item.TinhTrang);
                        return;
                    }



                }

            }

            foreach (var item in dsk.lstKhach)
            {
                if (txtFind.Text != null)
                {
                    if (item.MaKhach.ToString().Contains(txtFind.Text) || item.HoTen.ToString().Contains(txtFind.Text))
                    {
                        MessageBox.Show("Tìm thấy khách hàng: " + item.HoTen + " SĐT: " + item.SoDT + '\n'
                            + item.NgaySinh + '\n' + "Địa chỉ: " + item.DiaChi + "\nEmail: " + item.Email);
                        return;
                    }
                }
            }

            foreach (var item in lstnd)
            {
                if (txtFind.Text != null)
                {
                    if (item.TaiKhoan.ToString().Contains(txtFind.Text))
                    {
                        MessageBox.Show("Tìm thấy người dùng: " + item.TaiKhoan +"MK: "+item.MatKhau+ " Vai trò: " + item.VaiTro + '\n'
                            + "Email: " + item.Email + "\nNgày đăng ký: " + item.NgayDangKy);
                        return;
                    }
                }
            }

        }
    }
}
