namespace AdminApp
{
    partial class RoomManagement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grbRoom = new Guna.UI2.WinForms.Guna2GroupBox();
            this.pbPhong = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnChiTiet = new Guna.UI2.WinForms.Guna2Button();
            this.lblMaPhong = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblSoPhong = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dgvPhong = new System.Windows.Forms.DataGridView();
            this.lblTenPhong = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblMPhong = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblDienTich = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblGiaPhong = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTinhTrang = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblSoNguoiToiDa = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblNoiThat = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblMoTa = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.grbRoom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhong)).BeginInit();
            this.SuspendLayout();
            // 
            // grbRoom
            // 
            this.grbRoom.Controls.Add(this.guna2TextBox1);
            this.grbRoom.Controls.Add(this.lblMoTa);
            this.grbRoom.Controls.Add(this.lblNoiThat);
            this.grbRoom.Controls.Add(this.lblSoNguoiToiDa);
            this.grbRoom.Controls.Add(this.lblTinhTrang);
            this.grbRoom.Controls.Add(this.lblGiaPhong);
            this.grbRoom.Controls.Add(this.lblDienTich);
            this.grbRoom.Controls.Add(this.lblMPhong);
            this.grbRoom.Controls.Add(this.lblTenPhong);
            this.grbRoom.Controls.Add(this.pbPhong);
            this.grbRoom.Controls.Add(this.btnChiTiet);
            this.grbRoom.Controls.Add(this.lblMaPhong);
            this.grbRoom.Controls.Add(this.lblSoPhong);
            this.grbRoom.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbRoom.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grbRoom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.grbRoom.Location = new System.Drawing.Point(0, 0);
            this.grbRoom.Name = "grbRoom";
            this.grbRoom.Size = new System.Drawing.Size(1303, 500);
            this.grbRoom.TabIndex = 2;
            this.grbRoom.Click += new System.EventHandler(this.grbRoom_Click);
            // 
            // pbPhong
            // 
            this.pbPhong.ImageRotate = 0F;
            this.pbPhong.Location = new System.Drawing.Point(22, 61);
            this.pbPhong.Name = "pbPhong";
            this.pbPhong.Size = new System.Drawing.Size(418, 416);
            this.pbPhong.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPhong.TabIndex = 8;
            this.pbPhong.TabStop = false;
            this.pbPhong.Click += new System.EventHandler(this.pbPhong_Click);
            // 
            // btnChiTiet
            // 
            this.btnChiTiet.AutoRoundedCorners = true;
            this.btnChiTiet.BackColor = System.Drawing.Color.Transparent;
            this.btnChiTiet.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnChiTiet.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnChiTiet.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnChiTiet.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnChiTiet.FillColor = System.Drawing.Color.CadetBlue;
            this.btnChiTiet.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnChiTiet.ForeColor = System.Drawing.Color.White;
            this.btnChiTiet.Location = new System.Drawing.Point(1125, 393);
            this.btnChiTiet.Name = "btnChiTiet";
            this.btnChiTiet.Size = new System.Drawing.Size(134, 41);
            this.btnChiTiet.TabIndex = 3;
            this.btnChiTiet.Text = "Chi tiet";
            this.btnChiTiet.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // lblMaPhong
            // 
            this.lblMaPhong.BackColor = System.Drawing.Color.Transparent;
            this.lblMaPhong.Location = new System.Drawing.Point(380, 110);
            this.lblMaPhong.Name = "lblMaPhong";
            this.lblMaPhong.Size = new System.Drawing.Size(0, 0);
            this.lblMaPhong.TabIndex = 2;
            this.lblMaPhong.Text = null;
            // 
            // lblSoPhong
            // 
            this.lblSoPhong.BackColor = System.Drawing.Color.Transparent;
            this.lblSoPhong.Location = new System.Drawing.Point(380, 61);
            this.lblSoPhong.Name = "lblSoPhong";
            this.lblSoPhong.Size = new System.Drawing.Size(0, 0);
            this.lblSoPhong.TabIndex = 1;
            this.lblSoPhong.Text = null;
            // 
            // dgvPhong
            // 
            this.dgvPhong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhong.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvPhong.Location = new System.Drawing.Point(0, 506);
            this.dgvPhong.Name = "dgvPhong";
            this.dgvPhong.RowHeadersWidth = 51;
            this.dgvPhong.RowTemplate.Height = 24;
            this.dgvPhong.Size = new System.Drawing.Size(1303, 313);
            this.dgvPhong.TabIndex = 6;
            this.dgvPhong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhong_CellClick);
            // 
            // lblTenPhong
            // 
            this.lblTenPhong.BackColor = System.Drawing.Color.Transparent;
            this.lblTenPhong.Font = new System.Drawing.Font("Bahnschrift Condensed", 10.8F, System.Drawing.FontStyle.Bold);
            this.lblTenPhong.Location = new System.Drawing.Point(446, 86);
            this.lblTenPhong.Name = "lblTenPhong";
            this.lblTenPhong.Size = new System.Drawing.Size(65, 24);
            this.lblTenPhong.TabIndex = 17;
            this.lblTenPhong.Text = "Tên phòng";
            // 
            // lblMPhong
            // 
            this.lblMPhong.BackColor = System.Drawing.Color.Transparent;
            this.lblMPhong.Font = new System.Drawing.Font("Bahnschrift Condensed", 10.8F, System.Drawing.FontStyle.Bold);
            this.lblMPhong.Location = new System.Drawing.Point(450, 45);
            this.lblMPhong.Name = "lblMPhong";
            this.lblMPhong.Size = new System.Drawing.Size(61, 24);
            this.lblMPhong.TabIndex = 18;
            this.lblMPhong.Text = "Mã phòng";
            // 
            // lblDienTich
            // 
            this.lblDienTich.BackColor = System.Drawing.Color.Transparent;
            this.lblDienTich.Font = new System.Drawing.Font("Bahnschrift Condensed", 10.8F, System.Drawing.FontStyle.Bold);
            this.lblDienTich.Location = new System.Drawing.Point(615, 86);
            this.lblDienTich.Name = "lblDienTich";
            this.lblDienTich.Size = new System.Drawing.Size(58, 24);
            this.lblDienTich.TabIndex = 19;
            this.lblDienTich.Text = "Diện tích";
            // 
            // lblGiaPhong
            // 
            this.lblGiaPhong.BackColor = System.Drawing.Color.Transparent;
            this.lblGiaPhong.Font = new System.Drawing.Font("Bahnschrift Condensed", 10.8F, System.Drawing.FontStyle.Bold);
            this.lblGiaPhong.Location = new System.Drawing.Point(448, 162);
            this.lblGiaPhong.Name = "lblGiaPhong";
            this.lblGiaPhong.Size = new System.Drawing.Size(63, 24);
            this.lblGiaPhong.TabIndex = 20;
            this.lblGiaPhong.Text = "Giá phòng";
            // 
            // lblTinhTrang
            // 
            this.lblTinhTrang.BackColor = System.Drawing.Color.Transparent;
            this.lblTinhTrang.Font = new System.Drawing.Font("Bahnschrift Condensed", 10.8F, System.Drawing.FontStyle.Bold);
            this.lblTinhTrang.Location = new System.Drawing.Point(448, 226);
            this.lblTinhTrang.Name = "lblTinhTrang";
            this.lblTinhTrang.Size = new System.Drawing.Size(66, 24);
            this.lblTinhTrang.TabIndex = 21;
            this.lblTinhTrang.Text = "Tình trạng";
            // 
            // lblSoNguoiToiDa
            // 
            this.lblSoNguoiToiDa.BackColor = System.Drawing.Color.Transparent;
            this.lblSoNguoiToiDa.Font = new System.Drawing.Font("Bahnschrift Condensed", 10.8F, System.Drawing.FontStyle.Bold);
            this.lblSoNguoiToiDa.Location = new System.Drawing.Point(579, 226);
            this.lblSoNguoiToiDa.Name = "lblSoNguoiToiDa";
            this.lblSoNguoiToiDa.Size = new System.Drawing.Size(94, 24);
            this.lblSoNguoiToiDa.TabIndex = 22;
            this.lblSoNguoiToiDa.Text = "Số người tối đa";
            // 
            // lblNoiThat
            // 
            this.lblNoiThat.BackColor = System.Drawing.Color.Transparent;
            this.lblNoiThat.Font = new System.Drawing.Font("Bahnschrift Condensed", 10.8F, System.Drawing.FontStyle.Bold);
            this.lblNoiThat.Location = new System.Drawing.Point(448, 277);
            this.lblNoiThat.Name = "lblNoiThat";
            this.lblNoiThat.Size = new System.Drawing.Size(51, 24);
            this.lblNoiThat.TabIndex = 23;
            this.lblNoiThat.Text = "Nội thất";
            // 
            // lblMoTa
            // 
            this.lblMoTa.BackColor = System.Drawing.Color.Transparent;
            this.lblMoTa.Font = new System.Drawing.Font("Bahnschrift Condensed", 10.8F, System.Drawing.FontStyle.Bold);
            this.lblMoTa.Location = new System.Drawing.Point(448, 382);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(36, 24);
            this.lblMoTa.TabIndex = 24;
            this.lblMoTa.Text = "Mô tả";
            // 
            // guna2TextBox1
            // 
            this.guna2TextBox1.AutoRoundedCorners = true;
            this.guna2TextBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2TextBox1.BorderColor = System.Drawing.Color.LightGray;
            this.guna2TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox1.DefaultText = "";
            this.guna2TextBox1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox1.FillColor = System.Drawing.Color.Silver;
            this.guna2TextBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2TextBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox1.Location = new System.Drawing.Point(1085, 74);
            this.guna2TextBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2TextBox1.Name = "guna2TextBox1";
            this.guna2TextBox1.PlaceholderText = "";
            this.guna2TextBox1.SelectedText = "";
            this.guna2TextBox1.Size = new System.Drawing.Size(196, 36);
            this.guna2TextBox1.TabIndex = 25;
            // 
            // RoomManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1303, 819);
            this.Controls.Add(this.dgvPhong);
            this.Controls.Add(this.grbRoom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RoomManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RoomManagement";
            this.Load += new System.EventHandler(this.RoomManagement_Load);
            this.grbRoom.ResumeLayout(false);
            this.grbRoom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2GroupBox grbRoom;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblMaPhong;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSoPhong;
        private Guna.UI2.WinForms.Guna2Button btnChiTiet;
        private System.Windows.Forms.DataGridView dgvPhong;
        private Guna.UI2.WinForms.Guna2PictureBox pbPhong;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTenPhong;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblMoTa;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNoiThat;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSoNguoiToiDa;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTinhTrang;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblGiaPhong;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDienTich;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblMPhong;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
    }
}