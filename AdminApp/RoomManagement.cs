using AdminApp.model;
using AdminApp.model.MPhong;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
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

        void showimagebtn()
        {
            imgbtnFI1.Visible = true;
            imgbtnFI2.Visible = true;
            imgbtnFI3.Visible = true;
            imgbtnFI4.Visible = true;
        }
        #endregion

        #region processthings



        #endregion
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


        void loaddgvphong()
        {

            StyleDataGridView(dgvPhong);

            dgvPhong.DataSource = null;

            dgvPhong.DataSource = dsp.getAllPhong();
            dgvPhong.Columns["MaPhong"].HeaderText = "Mã phòng";
            dgvPhong.Columns["TenPhong"].HeaderText = "Tên phòng";
            dgvPhong.Columns["DienTich"].HeaderText = "Diện tích (m²)";
            dgvPhong.Columns["GiaPhong"].HeaderText = "Giá phòng";
            dgvPhong.Columns["TinhTrang"].HeaderText = "Tình trạng";
            dgvPhong.Columns["SoNguoiToiDa"].HeaderText = "Số người tối đa";
            dgvPhong.Columns["AnhChinh"].HeaderText = "Ảnh";
            dgvPhong.Columns["MoTaChiTiet"].HeaderText = "Mô tả chi tiết";
            dgvPhong.Columns["NoiThat"].HeaderText = "Nội thất";

            dgvPhong.Columns["GiaPhong"].DefaultCellStyle.Format = "N0";

            dgvPhong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            guna2GradientButton2.Visible = false;
        }

        private void RoomManagement_Load(object sender, EventArgs e)
        {
            loaddgvphong();

            loadthings();

            imgbtnFI1.Click += SubImage_Click;
            imgbtnFI2.Click += SubImage_Click;
            imgbtnFI3.Click += SubImage_Click;
            imgbtnFI4.Click += SubImage_Click;

        }

        private void dgvPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            guna2GradientButton2.Visible = false;
            btnIn.Enabled = true;
            btnThemPhong.Enabled = true;
            btnXoaPhong.Enabled = true;
            //string sophopng = "";
            //string anhphong = "";
            //if (e.RowIndex >= 0)
            //{

            //    DataGridViewRow r = dgvPhong.Rows[e.RowIndex];

            //    showtext();
            //    hide_bordertext();
            //    showlbl();
            //    txtReadOnly();
            //    showimagebtn();



            //    string map = r.Cells["MaPhong"].Value.ToString();
            //    sophopng = map.Last().ToString();
            //    anhphong= r.Cells["AnhChinh"].Value.ToString();
            //    //pbPhong.ImageLocation = @"Resources\ImagesRooms\room1\P101_main.jpg";

            //    //load anh lne imgbtn

            //    imgbtnFI1.Image = null;
            //    imgbtnFI2.Image = null;
            //    imgbtnFI3.Image = null;
            //    imgbtnFI4.Image = null;

            //    string roomFolder = Path.Combine(Application.StartupPath, "Resources", "ImagesRooms", "room" + sophopng);



            //    for (int i = 1; i <= 4; i++)
            //    {
            //        string subImagePath = Path.Combine(roomFolder, $"{map}_{i + 1}.jpg");
            //        if (File.Exists(subImagePath))
            //        {
            //            switch (i)
            //            {
            //                case 1: imgbtnFI1.Image = System.Drawing.Image.FromFile(subImagePath); break;
            //                case 2: imgbtnFI2.Image = System.Drawing.Image.FromFile(subImagePath); break;
            //                case 3: imgbtnFI3.Image = System.Drawing.Image.FromFile(subImagePath); break;
            //                case 4: imgbtnFI4.Image = System.Drawing.Image.FromFile(subImagePath); break;
            //            }
            //        }
            //    }



            //    //

            //    grbRoom.Text = "Room " + sophopng;

            //    txtMaPhong.Text = map;

            //    txtTenPhong.Text = r.Cells["TenPhong"].Value.ToString();
            //    txtGiaPhong.Text= r.Cells["GiaPhong"].Value.ToString();
            //    txtNoiThat.Text= r.Cells["NoiThat"].Value.ToString();
            //    txtDienTich.Text= r.Cells["DienTich"].Value.ToString();
            //    txtTinhTrang.Text= r.Cells["TinhTrang"].Value.ToString();
            //    txtSoNguoiToiDa.Text= r.Cells["SoNguoiToiDa"].Value.ToString();
            //    txtMoTa.Text= r.Cells["MoTaChiTiet"].Value.ToString();

            //    pbPhong.ImageLocation = @"Resources\ImagesRooms\room" + sophopng + @"\" + anhphong;
            //    string mainImagePath = Path.Combine(Application.StartupPath, "Resources", "ImagesRooms", "room" + sophopng, anhphong);
            //    if (File.Exists(mainImagePath))
            //        pbPhong.Image = System.Drawing.Image.FromFile(mainImagePath);
            //    else
            //        pbPhong.Image = null; // tránh lỗi nếu ảnh không tồn tại




            //}
            //else
            //{

            //}


            //string sophopng = "";
            //string anhphong = "";
            //if (e.RowIndex >= 0)
            //{

            //    DataGridViewRow r = dgvPhong.Rows[e.RowIndex];

            //    showtext();
            //    hide_bordertext();
            //    showlbl();
            //    txtReadOnly();
            //    showimagebtn();



            //    string map = r.Cells["MaPhong"].Value.ToString();
            //    sophopng = map.Last().ToString();
            //    anhphong = r.Cells["AnhChinh"].Value.ToString();
            //    //pbPhong.ImageLocation = @"Resources\ImagesRooms\room1\P101_main.jpg";

            //    //load anh lne imgbtn

            //    imgbtnFI1.Image = null;
            //    imgbtnFI2.Image = null;
            //    imgbtnFI3.Image = null;
            //    imgbtnFI4.Image = null;

            //    string roomFolder = Path.Combine(Application.StartupPath, "Resources", "ImagesRooms", "room" + sophopng);



            //    for (int i = 1; i <= 4; i++)
            //    {
            //        string subImagePath = Path.Combine(roomFolder, $"Hinh{i}.jpg");
            //        if (File.Exists(subImagePath))
            //        {
            //            switch (i)
            //            {
            //                case 1: imgbtnFI1.Image = System.Drawing.Image.FromFile(subImagePath); break;
            //                case 2: imgbtnFI2.Image = System.Drawing.Image.FromFile(subImagePath); break;
            //                case 3: imgbtnFI3.Image = System.Drawing.Image.FromFile(subImagePath); break;
            //                case 4: imgbtnFI4.Image = System.Drawing.Image.FromFile(subImagePath); break;
            //            }
            //        }
            //    }



            //    //

            //    grbRoom.Text = "Room " + sophopng;

            //    txtMaPhong.Text = map;

            //    txtTenPhong.Text = r.Cells["TenPhong"].Value.ToString();
            //    txtGiaPhong.Text = r.Cells["GiaPhong"].Value.ToString();
            //    txtNoiThat.Text = r.Cells["NoiThat"].Value.ToString();
            //    txtDienTich.Text = r.Cells["DienTich"].Value.ToString();
            //    txtTinhTrang.Text = r.Cells["TinhTrang"].Value.ToString();
            //    txtSoNguoiToiDa.Text = r.Cells["SoNguoiToiDa"].Value.ToString();
            //    txtMoTa.Text = r.Cells["MoTaChiTiet"].Value.ToString();

            //    pbPhong.ImageLocation = @"Resources\ImagesRooms\room" +anhphong;
            //    string mainImagePath = Path.Combine(Application.StartupPath, "Resources", "ImagesRooms", anhphong);
            //    if (File.Exists(mainImagePath))
            //        pbPhong.Image = System.Drawing.Image.FromFile(mainImagePath);
            //    else
            //        pbPhong.Image = null; // tránh lỗi nếu ảnh không tồn tại




            //}
            //else
            //{

            //}

            if (e.RowIndex < 0) return;

            DataGridViewRow r = dgvPhong.Rows[e.RowIndex];

            showtext();
            hide_bordertext();
            showlbl();
            txtReadOnly();
            showimagebtn();

            // ---- Lấy dữ liệu ----
            string maPhong = r.Cells["MaPhong"].Value.ToString();               // P022
            string anhChinhDb = r.Cells["AnhChinh"].Value.ToString();          // room22/Hinh1.jpg

            // ---- Load ảnh chính ----
            string mainImgPath = Path.Combine(Application.StartupPath,
                "Resources", "ImagesRooms", anhChinhDb);

            if (File.Exists(mainImgPath))
                pbPhong.Image = System.Drawing.Image.FromFile(mainImgPath);
            else
                pbPhong.Image = null;

            // ---- Folder ảnh của phòng ----
            string roomFolder = Path.Combine(Application.StartupPath,
                "Resources", "ImagesRooms", Path.GetDirectoryName(anhChinhDb));

            // Reset ảnh phụ
            imgbtnFI1.Image = null;
            imgbtnFI2.Image = null;
            imgbtnFI3.Image = null;
            imgbtnFI4.Image = null;

            // ---- Load ảnh phụ Hinh1–Hinh4 ----
            for (int i = 1; i <= 4; i++)
            {
                string subImg = Path.Combine(roomFolder, $"Hinh{i}.jpg");

                if (File.Exists(subImg))
                {
                    switch (i)
                    {
                        case 1: imgbtnFI1.Image = System.Drawing.Image.FromFile(subImg); break;
                        case 2: imgbtnFI2.Image = System.Drawing.Image.FromFile(subImg); break;
                        case 3: imgbtnFI3.Image = System.Drawing.Image.FromFile(subImg); break;
                        case 4: imgbtnFI4.Image = System.Drawing.Image.FromFile(subImg); break;
                    }
                }
            }

            // ---- Load thông tin phòng ----
            grbRoom.Text = maPhong;
            txtMaPhong.Text = maPhong;
            txtTenPhong.Text = r.Cells["TenPhong"].Value.ToString();
            txtGiaPhong.Text = r.Cells["GiaPhong"].Value.ToString();
            txtNoiThat.Text = r.Cells["NoiThat"].Value.ToString();
            txtDienTich.Text = r.Cells["DienTich"].Value.ToString();
            txtTinhTrang.Text = r.Cells["TinhTrang"].Value.ToString();
            txtSoNguoiToiDa.Text = r.Cells["SoNguoiToiDa"].Value.ToString();
            txtMoTa.Text = r.Cells["MoTaChiTiet"].Value.ToString();
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
            guna2GradientButton2.Visible = true;
            btnIn.Enabled= false;
            btnThemPhong.Enabled= false;
            btnXoaPhong.Enabled= false;
            //DSPhong dsp = new DSPhong();
            //DSHinhAnhPhong dsImg = new DSHinhAnhPhong();

            //// 1. Tạo object phòng
            //Phong p = new Phong()
            //{
            //    MaPhong = txtMaPhong.Text,
            //    TenPhong = txtTenPhong.Text,
            //    DienTich = txtDienTich.Text,
            //    GiaPhong = txtGiaPhong.Text,
            //    MoTaChiTiet = txtMoTa.Text,
            //    NoiThat = txtNoiThat.Text,
            //    SoNguoiToiDa = int.Parse(txtSoNguoiToiDa.Text),
            //    CoGac = "0",
            //    Tang = "1",
            //    LoaiPhong = "Duplex",
            //    MaChu = "1",
            //    AnhChinh = ""
            //};

            //// 2. Insert phòng trước
            //if (!dsp.addPhong(p))
            //{
            //    MessageBox.Show("Lỗi thêm phòng!");
            //    return;
            //}

            //// 3. Tạo folder lưu ảnh
            //string roomFolder = Path.Combine(Application.StartupPath, "Resources", "ImagesRooms", p.MaPhong);
            //if (!Directory.Exists(roomFolder))
            //    Directory.CreateDirectory(roomFolder);

            //bool first = true;

            //// 4. Copy ảnh và insert DB
            //foreach (string file in selectedImages)
            //{
            //    string fileName = Path.GetFileName(file);
            //    string destPath = Path.Combine(roomFolder, fileName);

            //    File.Copy(file, destPath, true);

            //    // Lưu DB
            //    string relativePath = $"{p.MaPhong}/{fileName}";
            //    dsImg.InsertHinhAnh(p.MaPhong, relativePath);

            //    // Ảnh chính
            //    if (first)
            //    {
            //        dsImg.UpdateAnhChinh(p.MaPhong, relativePath);
            //        first = false;
            //    }
            //}

            //MessageBox.Show("Thêm phòng + ảnh thành công!");

            //loaddgvphong();
            showtext();
            showlbl();
            show_bordertext();
            txtNonRdonly();
            showimagebtn();

            // Reset tất cả textbox
            txtMaPhong.Text = "PXXX";
            txtTenPhong.Text = "Phong so X";
            txtGiaPhong.Text = "X000000";
            txtDienTich.Text = "";
            txtNoiThat.Text = "FUll";
            txtMoTa.Text = "Nhu hinh";
            txtTinhTrang.Text = "Trống"; 
            txtSoNguoiToiDa.Text = "2";

            // Reset ảnh
            pbPhong.Image = null;
            imgbtnFI1.Image = null;
            imgbtnFI2.Image = null;
            imgbtnFI3.Image = null;
            imgbtnFI4.Image = null;

            selectedImages.Clear();
        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {

        }

        private void dgvPhong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        #region them phong

        // Hàm hoán đổi ảnh giữa ảnh chính và ảnh phụ
        private void SubImage_Click(object sender, EventArgs e)
        {
            var clicked = sender as Guna.UI2.WinForms.Guna2ImageButton;
            if (clicked == null) return;

            System.Drawing.Image temp = pbPhong.Image;
            pbPhong.Image = clicked.Image;
            clicked.Image = temp;
        }
        List<string> selectedImages = new List<string>();

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Filter = "Image Files|*.jpg;*.png;*.jpeg";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                selectedImages = ofd.FileNames.ToList();
                MessageBox.Show($"Đã chọn {selectedImages.Count} ảnh.");
            }
        }
        private void SaveImagesForRoom(Phong p)
        {
            DSHinhAnhPhong dsImg = new DSHinhAnhPhong();

            // Lấy số phòng từ MaPhong (VD: P022 → 22)
            int soPhong = int.Parse(p.MaPhong.Substring(1));
            string folderName = "room" + soPhong;

            // Tạo folder
            string roomFolder = Path.Combine(Application.StartupPath,
                "Resources", "ImagesRooms", folderName);

            if (!Directory.Exists(roomFolder))
                Directory.CreateDirectory(roomFolder);

            int index = 1;

            foreach (string src in selectedImages)
            {
                string ext = Path.GetExtension(src).ToLower();
                if (ext != ".jpg") ext = ".jpg"; // tự convert PNG → JPG

                string newFileName = $"Hinh{index}{ext}";
                string destPath = Path.Combine(roomFolder, newFileName);

                File.Copy(src, destPath, true);

                string urlDb = $"{folderName}/{newFileName}";

                // Insert ảnh phụ
                dsImg.InsertHinhAnh(p.MaPhong, urlDb);

                // Ảnh chính = Hinh1
                if (index == 1)
                    dsImg.UpdateAnhChinh(p.MaPhong, urlDb);

                index++;
            }
        }

        


        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaPhong.Text) ||
        string.IsNullOrWhiteSpace(txtTenPhong.Text) ||
        string.IsNullOrWhiteSpace(txtGiaPhong.Text) ||
        string.IsNullOrWhiteSpace(txtDienTich.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc!");
                return;
            }

            // 2. Tạo object phòng
            Phong p = new Phong()
            {
                MaPhong = txtMaPhong.Text.Trim(),
                TenPhong = txtTenPhong.Text.Trim(),
                DienTich = txtDienTich.Text.Trim(),
                GiaPhong = txtGiaPhong.Text.Trim(),
                MoTaChiTiet = txtMoTa.Text.Trim(),
                NoiThat = txtNoiThat.Text.Trim(),
                TinhTrang = "Trống",
                SoNguoiToiDa = int.TryParse(txtSoNguoiToiDa.Text, out int so) ? so : 1,
                CoGac = false,
                Tang = "1",
                LoaiPhong = "Duplex",
                MaChu = "1",
                AnhChinh = ""
            };

            // 3. Insert phòng vào DB
            if (!dsp.addPhong(p))
            {
                MessageBox.Show("Thêm phòng thất bại! (Kiểm tra mã phòng có bị trùng)");
                return;
            }

            // 4. Lưu ảnh đúng chuẩn
            SaveImagesForRoom(p);

            MessageBox.Show("Lưu phòng + ảnh thành công!");
            loaddgvphong();
            //    if (string.IsNullOrWhiteSpace(txtMaPhong.Text) ||
            //string.IsNullOrWhiteSpace(txtTenPhong.Text) ||
            //string.IsNullOrWhiteSpace(txtGiaPhong.Text) ||
            //string.IsNullOrWhiteSpace(txtDienTich.Text))
            //    {
            //        MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc!");
            //        return;
            //    }

            //    // 2. Tạo object Phong
            //    Phong p = new Phong()
            //    {
            //        MaPhong = txtMaPhong.Text.Trim(),
            //        TenPhong = txtTenPhong.Text.Trim(),
            //        DienTich = txtDienTich.Text.Trim(),
            //        GiaPhong = txtGiaPhong.Text.Trim(),
            //        MoTaChiTiet = txtMoTa.Text.Trim(),
            //        NoiThat = txtNoiThat.Text.Trim(),
            //        TinhTrang = "Trống",
            //        SoNguoiToiDa = int.TryParse(txtSoNguoiToiDa.Text, out int so) ? so : 1,
            //        CoGac = false,
            //        Tang = "1",
            //        LoaiPhong = "Duplex",
            //        MaChu = "1",
            //        AnhChinh = ""
            //    };

            //    // 3. Insert phòng vào DB
            //    if (!dsp.addPhong(p))
            //    {
            //        MessageBox.Show("Thêm phòng thất bại!");
            //        return;
            //    }

            //    // 4. Tạo folder lưu ảnh
            //    string roomFolder = Path.Combine(Application.StartupPath, "Resources", "ImagesRooms", p.MaPhong);
            //    if (!Directory.Exists(roomFolder))
            //        Directory.CreateDirectory(roomFolder);

            //    var dsImg = new DSHinhAnhPhong();
            //    bool first = true;

            //    // 5. Copy ảnh và insert vào DB
            //    foreach (string file in selectedImages)
            //    {
            //        string fileName = Path.GetFileName(file);
            //        string destPath = Path.Combine(roomFolder, fileName);

            //        File.Copy(file, destPath, true);

            //        string urlDb = $"{p.MaPhong}/{fileName}";

            //        // Insert ảnh phụ
            //        dsImg.InsertHinhAnh(p.MaPhong, urlDb);

            //        // Ảnh chính là ảnh đầu tiên
            //        if (first)
            //        {
            //            dsImg.UpdateAnhChinh(p.MaPhong, urlDb);
            //            first = false;
            //        }
            //    }


            //    MessageBox.Show("Lưu phòng + ảnh thành công!");

            //    loaddgvphong();
        }
        #endregion

        #region xoa phong

        private void DeleteRoomImages(string maPhong)
        {
            // Lấy số phòng từ P022 → 22
            int soPhong = int.Parse(maPhong.Substring(1));
            string folderName = "room" + soPhong;

            string folderPath = Path.Combine(Application.StartupPath,
                "Resources", "ImagesRooms", folderName);

            if (Directory.Exists(folderPath))
            {
                Directory.Delete(folderPath, true);  // xóa cả folder + file trong đó
            }
        }


        private void btnXoaPhong_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaPhong.Text))
            {
                MessageBox.Show("Chưa chọn phòng để xóa!");
                return;
            }

            string maPhong = txtMaPhong.Text.Trim();

            if (MessageBox.Show($"Xóa phòng {maPhong} ?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            // 1. Xóa ảnh trong DB
            DSHinhAnhPhong dsImg = new DSHinhAnhPhong();
            dsImg.DeleteImagesByRoom(maPhong);

            // 2. Xóa phòng trong DB
            if (!dsp.deletePhong(maPhong))
            {
                MessageBox.Show("Xóa phòng thất bại!");
                return;
            }

            // 3. Xóa folder ảnh trong bin
            DeleteRoomImages(maPhong);

            MessageBox.Show("Đã xóa phòng & ảnh thành công!");

            loaddgvphong();
            loadthings();
        }

        #endregion
    }
}
