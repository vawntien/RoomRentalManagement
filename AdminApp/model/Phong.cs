using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApp.model
{
    public class Phong
    {
        string maPhong, tenPhong, dienTich, giaPhong, tinhTrang, soNguoiToiDa, anhChinh, moTaChiTiet, noiThat, coGac, tang, loaiPhong, maChu;

        public string MaPhong { get => maPhong; set => maPhong = value; }
        public string TenPhong { get => tenPhong; set => tenPhong = value; }
        public string DienTich { get => dienTich; set => dienTich = value; }
        public string GiaPhong { get => giaPhong; set => giaPhong = value; }
        public string TinhTrang { get => tinhTrang; set => tinhTrang = value; }
        public string SoNguoiToiDa { get => soNguoiToiDa; set => soNguoiToiDa = value; }
        public string AnhChinh { get => anhChinh; set => anhChinh = value; }
        public string MoTaChiTiet { get => moTaChiTiet; set => moTaChiTiet = value; }
        public string NoiThat { get => noiThat; set => noiThat = value; }
        public string CoGac { get => coGac; set => coGac = value; }
        public string Tang { get => tang; set => tang = value; }
        public string LoaiPhong { get => loaiPhong; set => loaiPhong = value; }
        public string MaChu { get => maChu; set => maChu = value; }

        public Phong() { }
    }
}
