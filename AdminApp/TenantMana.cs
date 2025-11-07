using AdminApp.model;
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
        DSPhong dsp = new DSPhong();
        private object flpImages;

        void loaddgvPhongTro()
        {
            dgvPhongTro.DataSource = null;

            dgvPhongTro.DataSource = dsp.getAllPhong();
        }
        public TenantMana()
        {
            InitializeComponent();
        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void TenantMana_Load(object sender, EventArgs e)
        {
            loaddgvPhongTro();
        }

        private void LoadImages()
        {

        }

        private void dgvPhongTroo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}
