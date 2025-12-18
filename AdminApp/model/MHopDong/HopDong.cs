using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApp.model.MHopDong
{
    public class HopDong
    {
        int maHopDong;
        string maPhong;
        int maKhach, maChu;
        string ngayBatDau,ngayKetThuc,trangThai,ngayTao;
        double tienCoc;

        public int MaHopDong { get => maHopDong; set => maHopDong = value; }
        public string MaPhong { get => maPhong; set => maPhong = value; }
        public int MaKhach { get => maKhach; set => maKhach = value; }
        public int MaChu { get => maChu; set => maChu = value; }
        public string NgayBatDau { get => ngayBatDau; set => ngayBatDau = value; }
        public string NgayKetThuc { get => ngayKetThuc; set => ngayKetThuc = value; }
        public double TienCoc { get => tienCoc; set => tienCoc = value; }
        public string TrangThai { get => trangThai; set => trangThai = value; }
        public string NgayTao { get => ngayTao; set => ngayTao = value; }

        public HopDong() { }
    }
}
