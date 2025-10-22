/* =========================================================
   CƠ SỞ DỮ LIỆU: QLPhongTro (Phiên bản hoàn chỉnh mở rộng)
   - Bỏ dấu gạch dưới trong tên bảng
   - Thêm bảng ChuPhong (chủ phòng)
   - Thêm ràng buộc, khóa ngoại và default cho VaiTro:
       + Khách hàng: User (mặc định)
       + Chủ phòng: Admin
   - Thêm các bảng/ trường/ ràng buộc đề xuất để hệ thống thực tế hơn
   ========================================================= */

USE master;
GO

IF DB_ID(N'QLPhongTro') IS NOT NULL
    DROP DATABASE QLPhongTro;
GO

CREATE DATABASE QLPhongTro;
GO

USE QLPhongTro;
GO

/* =========================================================
   1. Bảng KhachThue (người thuê)
   ========================================================= */
CREATE TABLE KhachThue (
    MaKhach INT PRIMARY KEY IDENTITY(1,1),
    HoTen NVARCHAR(100) NOT NULL,
    CCCD NVARCHAR(20) UNIQUE NULL,
    SoDT NVARCHAR(15) UNIQUE NULL,
    Email NVARCHAR(100) NULL,
    DiaChi NVARCHAR(255) NULL,
    NgaySinh DATE NULL,
    NgayTao DATETIME DEFAULT GETDATE()
);
GO

/* =========================================================
   2. Bảng ChuPhong (chủ trọ - admin)
   ========================================================= */
CREATE TABLE ChuPhong (
    MaChu INT PRIMARY KEY IDENTITY(1,1),
    HoTen NVARCHAR(100) NOT NULL,
    CCCD NVARCHAR(20) UNIQUE NULL,
    SoDT NVARCHAR(15) UNIQUE NULL,
    Email NVARCHAR(100) NULL,
    DiaChi NVARCHAR(255) NULL,
    NgaySinh DATE NULL,
    NgayTao DATETIME DEFAULT GETDATE()
);
GO

/* =========================================================
   3. Bảng Phong
   ========================================================= */
CREATE TABLE Phong (
    MaPhong NVARCHAR(20) PRIMARY KEY,
    TenPhong NVARCHAR(255) NOT NULL,
    DienTich DECIMAL(7,2) NULL,
    GiaPhong DECIMAL(18,0) NOT NULL,
    TinhTrang NVARCHAR(50) NOT NULL DEFAULT N'Trống', -- Trống, Đã thuê, Sắp trống, Bảo trì
    SoNguoiToiDa INT NULL,
    AnhChinh NVARCHAR(255) NULL,
    MoTaChiTiet NVARCHAR(MAX) NULL,
    NoiThat NVARCHAR(500) NULL,
    CoGac BIT NOT NULL DEFAULT 0,
    Tang INT NULL,
    LoaiPhong NVARCHAR(50) NULL,
    MaChu INT NULL,  -- liên kết tới chủ phòng (nullable để tiện import)
    CONSTRAINT FK_Phong_ChuPhong FOREIGN KEY (MaChu) REFERENCES ChuPhong(MaChu) ON DELETE SET NULL
);
GO

/* =========================================================
   4. Bảng DichVu
   ========================================================= */
CREATE TABLE DichVu (
    MaDV NVARCHAR(20) PRIMARY KEY,
    TenDV NVARCHAR(100) NOT NULL,
    DonGia DECIMAL(18,0) NOT NULL,
    DonViTinh NVARCHAR(20) NULL
);
GO

/* =========================================================
   5. Bảng NguoiDung (quản lý tài khoản đăng nhập)
   ========================================================= */
CREATE TABLE NguoiDung (
    TaiKhoan NVARCHAR(50) PRIMARY KEY,
    MatKhau NVARCHAR(255) NOT NULL,
    VaiTro NVARCHAR(20) NOT NULL DEFAULT N'User' CHECK (VaiTro IN (N'User', N'Admin')),
    MaKhach INT NULL,
    MaChu INT NULL,
    Email NVARCHAR(100) NULL,
    NgayDangKy DATETIME DEFAULT GETDATE(),
    TrangThai NVARCHAR(20) NOT NULL DEFAULT N'Hoạt động' CHECK (TrangThai IN (N'Hoạt động', N'Khóa')),
    AnhDaiDien NVARCHAR(255) NULL,
    CONSTRAINT FK_NguoiDung_KhachThue FOREIGN KEY (MaKhach) REFERENCES KhachThue(MaKhach) ON DELETE SET NULL,
    CONSTRAINT FK_NguoiDung_ChuPhong FOREIGN KEY (MaChu) REFERENCES ChuPhong(MaChu) ON DELETE SET NULL
);
GO

/* =========================================================
   6. Bảng HopDong
   ========================================================= */
CREATE TABLE HopDong (
    MaHopDong INT PRIMARY KEY IDENTITY(1,1),
    MaPhong NVARCHAR(20) NOT NULL,
    MaKhach INT NOT NULL,
    MaChu INT NULL, -- lưu lại chủ phòng khi cần
    NgayBatDau DATE NOT NULL,
    NgayKetThuc DATE NOT NULL,
    TienCoc DECIMAL(18,0) NULL,
    TrangThai NVARCHAR(50) NOT NULL DEFAULT N'Đang hiệu lực',
    NgayTao DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_HopDong_Phong FOREIGN KEY (MaPhong) REFERENCES Phong(MaPhong),
    CONSTRAINT FK_HopDong_KhachThue FOREIGN KEY (MaKhach) REFERENCES KhachThue(MaKhach),
    CONSTRAINT FK_HopDong_ChuPhong FOREIGN KEY (MaChu) REFERENCES ChuPhong(MaChu) ON DELETE SET NULL,
    CONSTRAINT CK_HopDong_Ngay CHECK (NgayKetThuc > NgayBatDau)
);
GO

/* =========================================================
   7. Bảng HopDongDichVu (liên kết nhiều-nhiều HopDong ↔ DichVu)
   ========================================================= */
CREATE TABLE HopDongDichVu (
    MaHopDong INT NOT NULL,
    MaDV NVARCHAR(20) NOT NULL,
    SoLuong DECIMAL(10,2) DEFAULT 1,
    PRIMARY KEY (MaHopDong, MaDV),
    CONSTRAINT FK_HDDV_HopDong FOREIGN KEY (MaHopDong) REFERENCES HopDong(MaHopDong) ON DELETE CASCADE,
    CONSTRAINT FK_HDDV_DichVu FOREIGN KEY (MaDV) REFERENCES DichVu(MaDV)
);
GO

/* =========================================================
   8. Bảng AnhPhong (ảnh phụ của phòng)
   ========================================================= */
CREATE TABLE AnhPhong (
    MaAnh INT PRIMARY KEY IDENTITY(1,1),
    MaPhong NVARCHAR(20) NOT NULL,
    UrlHinhAnh NVARCHAR(255) NOT NULL,
    MoTa NVARCHAR(255) NULL,
    CONSTRAINT FK_AnhPhong_Phong FOREIGN KEY (MaPhong) REFERENCES Phong(MaPhong) ON DELETE CASCADE
);
GO

/* =========================================================
   9. Bảng GhiSoDienNuoc
   ========================================================= */
CREATE TABLE GhiSoDienNuoc (
    MaGhiSo INT PRIMARY KEY IDENTITY(1,1),
    MaHopDong INT NOT NULL,
    MaDV NVARCHAR(20) NOT NULL,
    ThangNam DATE NOT NULL, /* Lưu 01 của tháng, ví dụ '2025-01-01' biểu thị tháng 1/2025 */
    ChiSoCu INT NOT NULL,
    ChiSoMoi INT NOT NULL,
    SoLuongTieuThu AS (ChiSoMoi - ChiSoCu) PERSISTED,
    NgayGhi DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_GhiSo_HopDong FOREIGN KEY (MaHopDong) REFERENCES HopDong(MaHopDong) ON DELETE CASCADE,
    CONSTRAINT FK_GhiSo_DichVu FOREIGN KEY (MaDV) REFERENCES DichVu(MaDV)
);
GO

/* =========================================================
   10. Bảng HoaDon
   ========================================================= */
CREATE TABLE HoaDon (
    MaHD INT PRIMARY KEY IDENTITY(1,1),
    MaHopDong INT NOT NULL,
    ThangNam DATE NOT NULL,
    TongTien DECIMAL(18,0) NOT NULL,
    TrangThai NVARCHAR(50) NOT NULL DEFAULT N'Chưa thanh toán',
    NgayThanhToan DATE NULL,
    NgayLap DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_HoaDon_HopDong FOREIGN KEY (MaHopDong) REFERENCES HopDong(MaHopDong) ON DELETE CASCADE,
    CONSTRAINT CK_HoaDon_TongTien CHECK (TongTien >= 0)
);
GO

/* =========================================================
   11. Bảng ChiTietHD
   ========================================================= */
CREATE TABLE ChiTietHD (
    MaHD INT NOT NULL,
    MaDV NVARCHAR(20) NOT NULL,
    SoLuong DECIMAL(10,2) NOT NULL,
    DonGia DECIMAL(18,0) NOT NULL,
    ThanhTien AS (SoLuong * DonGia) PERSISTED,
    PRIMARY KEY (MaHD, MaDV),
    CONSTRAINT FK_ChiTietHD_HoaDon FOREIGN KEY (MaHD) REFERENCES HoaDon(MaHD) ON DELETE CASCADE,
    CONSTRAINT FK_ChiTietHD_DichVu FOREIGN KEY (MaDV) REFERENCES DichVu(MaDV)
);
GO

/* =========================================================
   12. Bảng SuCoBaoTri (sự cố/ bảo trì)
   ========================================================= */
CREATE TABLE SuCoBaoTri (
    MaSuCo INT PRIMARY KEY IDENTITY(1,1),
    MaHopDong INT NOT NULL,
    NoiDung NVARCHAR(MAX) NOT NULL,
    NgayBao DATETIME DEFAULT GETDATE(),
    TrangThai NVARCHAR(50) NOT NULL DEFAULT N'Mới báo', -- Mới báo, Đang xử lý, Đã xong
    ChiPhiSuaChua DECIMAL(18,0) NULL,
    GhiChu NVARCHAR(500) NULL,
    CONSTRAINT FK_SuCo_HopDong FOREIGN KEY (MaHopDong) REFERENCES HopDong(MaHopDong) ON DELETE CASCADE
);
GO

/* =========================================================
   13. Bảng QuanLyPhong (tùy chọn: nhiều chủ/nhân viên quản lý 1 phòng)
   ========================================================= */
CREATE TABLE QuanLyPhong (
    MaChu INT NOT NULL,
    MaPhong NVARCHAR(20) NOT NULL,
    VaiTroQuanLy NVARCHAR(50) NULL, -- ví dụ: 'Chủ chính', 'Nhân viên'
    NgayBatDau DATETIME DEFAULT GETDATE(),
    PRIMARY KEY (MaChu, MaPhong),
    CONSTRAINT FK_QuanLyPhong_ChuPhong FOREIGN KEY (MaChu) REFERENCES ChuPhong(MaChu) ON DELETE CASCADE,
    CONSTRAINT FK_QuanLyPhong_Phong FOREIGN KEY (MaPhong) REFERENCES Phong(MaPhong) ON DELETE CASCADE
);
GO

/* =========================================================
   14. Bảng LichSuHopDong (lưu lịch sử thay đổi hợp đồng)
   ========================================================= */
CREATE TABLE LichSuHopDong (
    MaLichSu INT PRIMARY KEY IDENTITY(1,1),
    MaHopDong INT NOT NULL,
    NgayThayDoi DATETIME DEFAULT GETDATE(),
    NguoiThucHien NVARCHAR(100) NULL, -- TaiKhoan hoặc tên người thao tác
    NoiDung NVARCHAR(MAX) NULL,
    CONSTRAINT FK_LSHD_HopDong FOREIGN KEY (MaHopDong) REFERENCES HopDong(MaHopDong) ON DELETE CASCADE
);
GO

/* =========================================================
   15. Bảng PhanHoiDanhGia (feedback / rating)
   ========================================================= */
CREATE TABLE PhanHoiDanhGia (
    MaDG INT PRIMARY KEY IDENTITY(1,1),
    MaPhong NVARCHAR(20) NOT NULL,
    MaKhach INT NOT NULL,
    DiemDanhGia INT NOT NULL CHECK (DiemDanhGia BETWEEN 1 AND 5),
    NoiDung NVARCHAR(MAX) NULL,
    NgayDanhGia DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_PhanHoi_Phong FOREIGN KEY (MaPhong) REFERENCES Phong(MaPhong) ON DELETE CASCADE,
    CONSTRAINT FK_PhanHoi_Khach FOREIGN KEY (MaKhach) REFERENCES KhachThue(MaKhach) ON DELETE CASCADE
);
GO

/* =========================================================
   16. Các index/ ràng buộc bổ sung (ví dụ)
   ========================================================= */
-- Index để tìm kiếm nhanh phòng theo trạng thái & chủ
CREATE INDEX IDX_Phong_TinhTrang ON Phong(TinhTrang);
CREATE INDEX IDX_Phong_MaChu ON Phong(MaChu);

-- Index nhanh cho hóa đơn theo trạng thái
CREATE INDEX IDX_HoaDon_TrangThai ON HoaDon(TrangThai);
GO

/* =========================================================
   DỮ LIỆU MẪU
   ========================================================= */

-- Dịch vụ mẫu
INSERT INTO DichVu (MaDV, TenDV, DonGia, DonViTinh) VALUES
(N'DIEN', N'Điện sinh hoạt', 4000, N'kWh'),
(N'NUOC', N'Nước sinh hoạt', 25000, N'm³'),
(N'NET', N'Internet cáp quang', 100000, N'tháng'),
(N'RAC', N'Phí vệ sinh, rác', 30000, N'tháng');

-- Thêm chủ phòng trước
INSERT INTO ChuPhong (HoTen, CCCD, SoDT, Email, DiaChi, NgaySinh)
VALUES (N'Phạm Văn Long', N'123456789000', N'0909123456', N'phaml@example.com', N'45 Bình Thạnh', '1980-03-15');

-- Thêm phòng (gắn MaChu)
INSERT INTO Phong (MaPhong, TenPhong, DienTich, GiaPhong, TinhTrang, SoNguoiToiDa, AnhChinh, MoTaChiTiet, NoiThat, CoGac, Tang, LoaiPhong, MaChu)
VALUES
(N'P101', N'Phòng 101 (View ban công)', 25.5, 3500000, N'Trống', 3, N'P101_main.jpg', N'Phòng tầng 1, có ban công riêng thoáng mát', N'Máy lạnh, Tủ lạnh, Kệ bếp', 1, 1, N'Đơn', 1),
(N'P102', N'Phòng 102 (Standard)', 22.0, 3000000, N'Trống', 2, N'P102_main.jpg', N'Phòng tiêu chuẩn, cửa sổ giếng trời', N'Máy lạnh, Kệ bếp', 0, 1, N'Đơn', 1);

-- Thêm người thuê mẫu
INSERT INTO KhachThue (HoTen, CCCD, SoDT, Email, DiaChi, NgaySinh)
VALUES (N'Nguyễn Văn An', N'001234567890', N'0909988776', N'nguyenvan.an@example.com', N'123 Đồng Nai', '1999-05-10');

-- Tạo tài khoản admin cho chủ phòng
INSERT INTO NguoiDung (TaiKhoan, MatKhau, VaiTro, MaChu, Email)
VALUES (N'admin1', N'123456', N'Admin', 1, N'admin1@example.com');

-- Tạo tài khoản user cho khách thuê
INSERT INTO NguoiDung (TaiKhoan, MatKhau, VaiTro, MaKhach, Email)
VALUES (N'user1', N'123456', DEFAULT, 1, N'user1@example.com');

-- Tạo hợp đồng thuê mẫu (liên kết Phong và Khach)
INSERT INTO HopDong (MaPhong, MaKhach, MaChu, NgayBatDau, NgayKetThuc, TienCoc, TrangThai)
VALUES (N'P101', 1, 1, '2025-01-01', '2025-12-31', 3000000, N'Đang hiệu lực');

-- Tạo một hóa đơn mẫu
INSERT INTO HoaDon (MaHopDong, ThangNam, TongTien, TrangThai)
VALUES (1, '2025-01-01', 850000, N'Chưa thanh toán');

-- Thêm chi tiết hóa đơn (ví dụ dịch vụ)
INSERT INTO ChiTietHD (MaHD, MaDV, SoLuong, DonGia)
VALUES (1, N'NET', 1, 100000);

-- Thêm ghi số điện nước mẫu
INSERT INTO GhiSoDienNuoc (MaHopDong, MaDV, ThangNam, ChiSoCu, ChiSoMoi)
VALUES (1, N'DIEN', '2025-01-01', 1200, 1250);

-- Thêm sự cố mẫu
INSERT INTO SuCoBaoTri (MaHopDong, NoiDung, TrangThai, ChiPhiSuaChua)
VALUES (1, N'Bồn nước rò rỉ', N'Mới báo', 0);

-- Thêm đánh giá mẫu
INSERT INTO PhanHoiDanhGia (MaPhong, MaKhach, DiemDanhGia, NoiDung)
VALUES (N'P101', 1, 5, N'Phòng sạch, view tốt.');

-- Thêm bản ghi quản lý phòng (tùy chọn)
INSERT INTO QuanLyPhong (MaChu, MaPhong, VaiTroQuanLy)
VALUES (1, N'P101', N'Chủ chính');

-- Thêm lịch sử hợp đồng (ví dụ)
INSERT INTO LichSuHopDong (MaHopDong, NguoiThucHien, NoiDung)
VALUES (1, N'admin1', N'Tạo hợp đồng ban đầu, tiền cọc 3.000.000');
GO

/* =========================================================
   GỢI Ý SỬ DỤNG VỀ SAU
   - Nếu bạn muốn Phong.MaChu bắt buộc (NOT NULL), hãy cập nhật các phòng hiện tại
     để có MaChu hợp lệ rồi ALTER COLUMN sang NOT NULL.
   - Tương tự nếu muốn HopDong.MaChu NOT NULL.
   - Có thể thêm trigger hoặc procedure:
       + Tự động cập nhật Phong.TinhTrang khi tạo/ket thuc HopDong
       + Tạo stored procedure tạo hóa đơn theo GhiSoDienNuoc + HopDongDichVu
   - Cân nhắc hash + salt cho MatKhau thay vì lưu plaintext (ở đây mẫu dùng plaintext để demo).
   ========================================================= */
