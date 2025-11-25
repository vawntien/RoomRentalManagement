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
                h.TienCoc = r["TienCoc"].ToString();
                h.TrangThai = r["TrangThai"].ToString();
                h.NgayTao = r["NgayTao"].ToString();
                lsthd.Add(h);
            }

            

            return lsthd;
        }
    }
}
