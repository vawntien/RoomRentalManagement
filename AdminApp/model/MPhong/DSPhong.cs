using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApp.model
{
    public class DSPhong
    {
        public List<Phong> lstPhong = new List<Phong>();
        public DSPhong() { }

        public List<Phong> getAllPhong()
        {
            lstPhong.Clear();
            SqlDataAdapter adapter = new SqlDataAdapter(ConnectionModel.execPhong, ConnectionModel.strcnn);

            DataSet ds = new DataSet();

            adapter.Fill(ds,"PHONG");

            foreach (DataRow row in ds.Tables["PHONG"].Rows)
            {
                Phong p = new Phong();
                p.MaPhong = row["MaPhong"].ToString();
                p.TenPhong = row["TenPhong"].ToString();
                p.DienTich = row["DienTich"].ToString();
                p.GiaPhong = row["GiaPhong"].ToString();
                p.TinhTrang = row["TinhTrang"].ToString();
                p.SoNguoiToiDa = int.Parse(row["SoNguoiToiDa"].ToString());
                p.AnhChinh = row["AnhChinh"].ToString();
                p.MoTaChiTiet = row["MoTaChiTiet"].ToString();
                p.NoiThat = row["NoiThat"].ToString();
                p.CoGac = row["CoGac"].ToString();
                p.Tang = row["Tang"].ToString();
                p.LoaiPhong = row["LoaiPhong"].ToString();
                p.MaChu = row["MaChu"].ToString();
                lstPhong.Add(p);
            }
            return lstPhong;
        }

        
    }
}
