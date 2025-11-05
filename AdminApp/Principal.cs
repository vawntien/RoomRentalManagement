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
    }
}
