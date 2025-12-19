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
using CrystalDecisions.Shared;

namespace AdminApp
{
    public partial class ContactMana : Form
    {
        DSHopDong dsh = new DSHopDong();
        public ContactMana()
        {
            InitializeComponent();
        }
        void loadbcao()
        {
            DSHopDong ds = new DSHopDong();
            var danhSachHopDong = ds.getallHopDong(); 
            
            HopDong rpt = new HopDong();
            rpt.SetDataSource(danhSachHopDong);

            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();
        }

      
        void loaddgvHopDong()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource=dsh.getallHopDong();
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

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            //crystalReportViewer1.ReportSource = new HopDong();
            //crystalReportViewer1.Refresh();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            AdminApp.HopDong rpt = PrepareReport();

            if (rpt != null)
            {
                crystalReportViewer1.ReportSource = rpt;
                crystalReportViewer1.Refresh();
            }
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private AdminApp.HopDong PrepareReport()
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.Index < 0)
            {
                MessageBox.Show("Vui lòng chọn một hợp đồng trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            try
            {
                int maHD = int.Parse(dataGridView1.CurrentRow.Cells["MaHopDong"].Value.ToString());

                DSHopDong ds = new DSHopDong();
                // Lấy dữ liệu chi tiết
                AdminApp.model.MHopDong.HopDong hopDongChiTiet = ds.getChiTiet(maHD);

                // Đưa vào list như code cũ của bạn
                List<AdminApp.model.MHopDong.HopDong> listData = new List<AdminApp.model.MHopDong.HopDong>();
                listData.Add(hopDongChiTiet);

                // Khởi tạo Report
                AdminApp.HopDong rpt = new AdminApp.HopDong();
                rpt.SetDataSource(listData);

                return rpt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu: " + ex.Message);
                return null;
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            // Gọi hàm chuẩn bị report (lấy lại dữ liệu mới nhất từ dòng đang chọn)
            AdminApp.HopDong rpt = PrepareReport();

            if (rpt != null)
            {
                try
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "PDF Files|*.pdf";
                    saveFileDialog.Title = "Lưu Hợp Đồng";

                    // Lấy lại Mã HD để đặt tên file cho đẹp
                    string maHD = dataGridView1.CurrentRow.Cells["MaHopDong"].Value.ToString();
                    saveFileDialog.FileName = "HopDong_" + maHD + ".pdf";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Xuất file
                        rpt.ExportToDisk(ExportFormatType.PortableDocFormat, saveFileDialog.FileName);

                        MessageBox.Show("Xuất file PDF thành công!\nĐường dẫn: " + saveFileDialog.FileName,
                                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất file: " + ex.Message);
                }
            }
        }
    }
}
