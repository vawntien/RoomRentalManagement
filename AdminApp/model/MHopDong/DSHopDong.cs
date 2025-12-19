using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApp.model.MHopDong
{
    public class DSHopDong
    {
        public List<HopDong> lsthd = new List<HopDong>();

        public DSHopDong() { }

        public HopDong getChiTiet(int maHD)
        {
            HopDong h = new HopDong();
            string sql = "SELECT * FROM HopDong WHERE MaHopDong = " + maHD;

            SqlDataAdapter adapter = new SqlDataAdapter(sql, ConnectionModel.strcnn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                DataRow r = dt.Rows[0];
                // Map dữ liệu từ SQL vào Class C#
                h.MaHopDong = int.Parse(r["MaHopDong"].ToString());
                h.MaPhong = r["MaPhong"].ToString();
                h.MaKhach = int.Parse(r["MaKhach"].ToString());
                h.MaChu = int.Parse(r["MaChu"].ToString());
                h.NgayBatDau = r["NgayBatDau"].ToString();
                h.NgayKetThuc = r["NgayKetThuc"].ToString();
                h.TienCoc = double.Parse(r["TienCoc"].ToString());
                h.TrangThai = r["TrangThai"].ToString();
                h.NgayTao = r["NgayTao"].ToString();
            }
            return h;
        }

        public List<HopDong> getallHopDong()
        {
            lsthd.Clear();

            SqlDataAdapter adapter = new SqlDataAdapter(ConnectionModel.execHopDong,ConnectionModel.strcnn);

            DataSet ds = new DataSet();

            adapter.Fill(ds,"HOPDONG");
            foreach(DataRow r in ds.Tables["HOPDONG"].Rows)
            {
                HopDong h = new HopDong();
                h.MaHopDong = int.Parse(r["MaHopDong"].ToString());
                h.MaPhong = r["MaPhong"].ToString();
                h.MaKhach = int.Parse(r["MaKhach"].ToString());
                h.MaChu = int.Parse(r["MaChu"].ToString());
                h.NgayBatDau = r["NgayBatDau"].ToString();
                h.NgayKetThuc = r["NgayKetThuc"].ToString();
                h.TienCoc = double.Parse(r["TienCoc"].ToString());
                h.TrangThai = r["TrangThai"].ToString();
                h.NgayTao = r["NgayTao"].ToString();
                lsthd.Add(h);
            }

            

            return lsthd;
        }
    }
}
