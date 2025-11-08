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

        private void TenantMana_Load(object sender, EventArgs e)
        {
            loaddgvKhachThue();
        }

        private void LoadImages()
        {

        }

        private void dgvPhongTroo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}
