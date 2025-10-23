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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                            "Bạn có muốn thoát không?",
                            "Xác nhận thoát",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);


            if (result == DialogResult.Yes)
            {

                Application.Exit();


            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "tien" && txtPassword.Text == "123")
            {
                Loading lding = new Loading();
                lding.Show();
                this.Hide();
            }
            else             {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
