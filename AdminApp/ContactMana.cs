using AdminApp.model.MHopDong;
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
    public partial class ContactMana : Form
    {
        DSHopDong dsh = new DSHopDong();
        public ContactMana()
        {
            InitializeComponent();
        }

      
        void loaddgvHopDong()
        {
            dgvContact.DataSource = null;
            dgvContact.DataSource=dsh.getallHopDong();
        }
        public void StyleGridView_Pro(DataGridView dgv)
        {
            dgv.BorderStyle = BorderStyle.None;
            dgv.BackgroundColor = Color.White;
            dgv.EnableHeadersVisualStyles = false;
            dgv.AllowUserToAddRows = false;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // ==== HEADER ====
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(121, 205, 205);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersHeight = 45;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // ==== ROWS ====
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(40, 40, 40);
            dgv.DefaultCellStyle.BackColor = Color.White;

            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(225, 235, 255);
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgv.RowTemplate.Height = 38;
            dgv.GridColor = Color.FromArgb(230, 230, 230);
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            // ==== ZEBRA STRIPES (hàng xen kẽ) ====
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 249, 255);

            // ==== CĂN LỀ ====
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                if (col.ValueType == typeof(int) || col.ValueType == typeof(long) || col.Name.Contains("Gia"))
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                else if (col.Name.Contains("Ma") || col.Name.Contains("ID"))
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                else
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            // ==== BO GÓC ĐEP ====
            dgv.AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;
        }


        private void ContactMana_Load(object sender, EventArgs e)
        {
            StyleGridView_Pro(dgvContact);

            loaddgvHopDong();
        }
    }
}
