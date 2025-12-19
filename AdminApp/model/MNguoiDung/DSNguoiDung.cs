using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminApp.model.MNguoiDung
{
    public class DSNguoiDung
    {
        public List<NguoiDung> lstNguoiDung = new List<NguoiDung>();
        public DSNguoiDung() { }

        public List<NguoiDung> getNguoiDung_By_Name(string name)
        {
            lstNguoiDung.Clear();
            SqlDataAdapter adapter = new SqlDataAdapter(ConnectionModel.execNguoiDung, ConnectionModel.strcnn);

            DataSet ds = new DataSet();

            adapter.Fill(ds, "NGUOIDUNG");

            foreach (DataRow row in ds.Tables["NGUOIDUNG"].Rows)
            {
                if (row["TaiKhoan"].ToString().Contains(name))
                {
                    NguoiDung nd = new NguoiDung();
                    nd.TaiKhoan = row["TaiKhoan"].ToString();
                    nd.MatKhau = row["MatKhau"].ToString();
                    nd.VaiTro = row["VaiTro"].ToString();
                    nd.TrangThai = row["TrangThai"].ToString();
                    if (row["MaKhach"] != DBNull.Value)
                    {
                        nd.MaKhach = int.Parse(row["MaKhach"].ToString());
                    }

                    nd.NgayDangKy = row["NgayDangKy"].ToString();
                    nd.Email = row["Email"].ToString();
                    lstNguoiDung.Add(nd);
                }    
                
            }
            return lstNguoiDung;
        }
        public List<NguoiDung> getAllNguoiDung()
        {
            lstNguoiDung.Clear();
            SqlDataAdapter adapter = new SqlDataAdapter(ConnectionModel.execNguoiDung, ConnectionModel.strcnn);

            DataSet ds = new DataSet();

            adapter.Fill(ds, "NGUOIDUNG");

            foreach (DataRow row in ds.Tables["NGUOIDUNG"].Rows)
            {
                NguoiDung nd = new NguoiDung();
                nd.TaiKhoan = row["TaiKhoan"].ToString();
                nd.MatKhau = row["MatKhau"].ToString();
                nd.VaiTro = row["VaiTro"].ToString();
                nd.TrangThai = row["TrangThai"].ToString();
                if(row["MaKhach"] != DBNull.Value)
                {
                    nd.MaKhach = int.Parse(row["MaKhach"].ToString());
                }
                    
                nd.NgayDangKy = row["NgayDangKy"].ToString();
                nd.Email= row["Email"].ToString();
                lstNguoiDung.Add(nd);
            }
            return lstNguoiDung;
        }

        public bool addNguoiDung(NguoiDung nd)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(ConnectionModel.execNguoiDung, ConnectionModel.strcnn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

            DataSet ds = new DataSet();

            adapter.Fill(ds, "NGUOIDUNG");
            int n = 0;
            try
            {
                DataRow r = ds.Tables["NGUOIDUNG"].NewRow();

                r["TaiKhoan"] = nd.TaiKhoan;
                r["MatKhau"] = nd.MatKhau;
                r["VaiTro"] = nd.VaiTro;
                r["TrangThai"] = nd.TrangThai;
                //r["MaKhach"] = nd.MaKhach;
                r["NgayDangKy"] = nd.NgayDangKy;
                r["Email"] = nd.Email;
                ds.Tables["NGUOIDUNG"].Rows.Add(r);

                n = adapter.Update(ds, "NGUOIDUNG");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Loi: " + ex.Message);
            }
            return n > 0;
        }

        public bool deleteNGUOIDUNG(string tk)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(ConnectionModel.execNguoiDung, ConnectionModel.strcnn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "NGUOIDUNG");
            DataRow[] rows = ds.Tables["NGUOIDUNG"].Select("TaiKhoan = '" + tk + "'");
            if (rows.Length > 0)
            {
                rows[0].Delete();
            }
            int n = adapter.Update(ds, "NGUOIDUNG");
            return n > 0;
        }

        public bool updateNGUOIDUNG(NguoiDung nd)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(ConnectionModel.execNguoiDung, ConnectionModel.strcnn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "NGUOIDUNG");
            DataRow[] rows = ds.Tables["NGUOIDUNG"].Select("TaiKhoan = '" + nd.TaiKhoan + "'");

            
            if (rows.Length > 0)
            {
                rows[0]["TaiKhoan"] = nd.TaiKhoan;
                rows[0]["MatKhau"] = nd.MatKhau;
                rows[0]["VaiTro"] = nd.VaiTro;
                rows[0]["TrangThai"] = nd.TrangThai;
                rows[0]["MaKhach"] = nd.MaKhach;
                rows[0]["NgayDangKy"] = nd.NgayDangKy;
                rows[0]["Email"] = nd.Email;
            }
            int n = adapter.Update(ds, "NGUOIDUNG");
            return n > 0;
        }
    }
}
