using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApp.model.MNguoiDung
{
    public class NguoiDung
    {
        string taiKhoan, matKhau, vaiTro;
        int maKhach;
        string email, ngayDangKy,trangThai;
        public string TaiKhoan { get => taiKhoan; set => taiKhoan = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public string VaiTro { get => vaiTro; set => vaiTro = value; }
        public int MaKhach {get => maKhach; set => maKhach = value; }
        public string Email { get => email; set => email = value; }
        public string NgayDangKy { get => ngayDangKy; set => ngayDangKy = value; }
        public string TrangThai { get => trangThai; set => trangThai = value; }
        public NguoiDung()
        {
        }
    }
}
