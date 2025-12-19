using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApp.model
{
    public static class ConnectionModel
    {
        public static string strcnn = "Data Source=.;Initial Catalog=QLPhongTro;Integrated Security=True;TrustServerCertificate=True";
        public static string execPhong = "select * from Phong";
        public static string execKhach = "select * from KhachThue";
        public static string execHopDong = "select * from HopDong";

    }
}
