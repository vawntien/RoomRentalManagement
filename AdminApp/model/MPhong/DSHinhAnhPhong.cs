using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApp.model.MPhong
{
    public class DSHinhAnhPhong
    {
        public bool InsertHinhAnh(string maPhong, string url)
        {
            string sql = "INSERT INTO AnhPhong (MaPhong, UrlHinhAnh) VALUES (@MaPhong, @UrlHinhAnh)";
            using (SqlConnection conn = new SqlConnection(ConnectionModel.strcnn))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaPhong", maPhong);
                cmd.Parameters.AddWithValue("@UrlHinhAnh", url);
                return cmd.ExecuteNonQuery() > 0;
            }
        }


        public bool UpdateAnhChinh(string maPhong, string url)
        {
            string sql = "UPDATE Phong SET AnhChinh = @AnhChinh WHERE MaPhong = @MaPhong";
            using (SqlConnection conn = new SqlConnection(ConnectionModel.strcnn))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaPhong", maPhong);
                cmd.Parameters.AddWithValue("@AnhChinh", url);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        internal void DeleteImagesByRoom(string maPhong)
        {
            string sql = "DELETE FROM AnhPhong WHERE MaPhong = @MaPhong";
            using (SqlConnection conn = new SqlConnection(ConnectionModel.strcnn))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaPhong", maPhong);
                cmd.ExecuteNonQuery();
            }
        }


    }
}
