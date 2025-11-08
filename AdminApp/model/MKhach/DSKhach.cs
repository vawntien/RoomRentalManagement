using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApp.model.MKhach
{
    public  class DSKhach
    {
        public List<Khach> lstKhach = new List<Khach>();

        public DSKhach() { }

        public List<Khach> getAllKhach()
        {

            lstKhach.Clear();

            SqlDataAdapter adapter = new SqlDataAdapter(ConnectionModel.execKhach,ConnectionModel.strcnn);

            DataSet ds = new DataSet();

            adapter.Fill(ds,"KHACHTHUE");

            foreach(DataRow d in ds.Tables["KHACHTHUE"].Rows)
            {
                Khach k = new Khach();
                k.MaKhach = int.Parse( d["MaKhach"].ToString());
                k.HoTen = d["HoTen"].ToString();
                k.CCCD = d["CCCD"].ToString();
                k.SoDT = d["SoDT"].ToString();
                k.Email = d["Email"].ToString();
                k.DiaChi = d["DiaChi"].ToString();
                k.NgaySinh = d["NgaySinh"].ToString();  
                k.NgayTao = d["NgayTao"].ToString();
                lstKhach.Add(k);
            }


            return lstKhach;
        }
    }
}
