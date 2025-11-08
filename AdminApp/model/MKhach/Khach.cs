using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApp.model.MKhach
{
    public class Khach
    {
        int maKhach;
        string hoTen, cCCD, soDT, email, diaChi, ngaySinh, ngayTao;

        public int MaKhach { get => maKhach; set => maKhach = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string CCCD { get => cCCD; set => cCCD = value; }
        public string SoDT { get => soDT; set => soDT = value; }
        public string Email { get => email; set => email = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string NgayTao { get => ngayTao; set => ngayTao = value; }
        

        public Khach()
        {
        }
    }
}
