using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

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

            adapter.Fill(ds, "PHONG");

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
                p.CoGac = row["CoGac"].ToString() == "1" ? true : false;
                p.Tang = row["Tang"].ToString();
                p.LoaiPhong = row["LoaiPhong"].ToString();
                p.MaChu = row["MaChu"].ToString();
                lstPhong.Add(p);
            }
            return lstPhong;
        }

        public bool addPhong(Phong phong)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(ConnectionModel.execPhong, ConnectionModel.strcnn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

            DataSet ds = new DataSet();

            adapter.Fill(ds, "PHONG");

            DataRow r = ds.Tables["PHONG"].NewRow();

            r["MaPhong"] = phong.MaPhong;
            r["TenPhong"] = phong.TenPhong;
            r["DienTich"] = phong.DienTich;
            r["GiaPhong"] = phong.GiaPhong;
            r["TinhTrang"] = "Trống";
            r["SoNguoiToiDa"] = phong.SoNguoiToiDa;
            r["AnhChinh"] = phong.AnhChinh;
            r["MoTaChiTiet"] = phong.MoTaChiTiet;
            r["NoiThat"] = phong.NoiThat;
            r["CoGac"] = phong.CoGac;
            r["Tang"] = phong.Tang;
            r["LoaiPhong"] = phong.LoaiPhong;
            r["MaChu"] = phong.MaChu;
            ds.Tables["PHONG"].Rows.Add(r);

            int n = adapter.Update(ds, "PHONG");
            return n > 0;

        }

        public bool deletePhong(string maPhong)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(ConnectionModel.execPhong, ConnectionModel.strcnn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "PHONG");
            DataRow[] rows = ds.Tables["PHONG"].Select("MaPhong = '" + maPhong + "'");
            if (rows.Length > 0)
            {
                rows[0].Delete();
            }
            int n = adapter.Update(ds, "PHONG");
            return n > 0;
        }

        public bool updatePhong(Phong phong)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(ConnectionModel.execPhong, ConnectionModel.strcnn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "PHONG");
            DataRow[] rows = ds.Tables["PHONG"].Select("MaPhong = '" + phong.MaPhong + "'");
            if (rows.Length > 0)
            {
                rows[0]["TenPhong"] = phong.TenPhong;
                rows[0]["DienTich"] = phong.DienTich;
                rows[0]["GiaPhong"] = phong.GiaPhong;
                rows[0]["TinhTrang"] = phong.TinhTrang;
                rows[0]["SoNguoiToiDa"] = phong.SoNguoiToiDa;
                rows[0]["AnhChinh"] = phong.AnhChinh;
                rows[0]["MoTaChiTiet"] = phong.MoTaChiTiet;
                rows[0]["NoiThat"] = phong.NoiThat;
                rows[0]["CoGac"] = phong.CoGac;
                rows[0]["Tang"] = phong.Tang;
                rows[0]["LoaiPhong"] = phong.LoaiPhong;
                rows[0]["MaChu"] = phong.MaChu;
            }
            int n = adapter.Update(ds, "PHONG");
            return n > 0;
        }
    }
}
