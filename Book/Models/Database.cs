using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;

namespace Book.Models
{
    public class Database
    {
        private readonly string connStr;

        public Database(IConfiguration configuration)
        {
            connStr = configuration.GetConnectionString("MyDBConnection")
                     ?? throw new InvalidOperationException("Chưa có MyDBConnection trong appsettings.json");
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connStr);
        }

        public DataTable LayDuLieu(string sql)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public int ThucThiLenh(string sql)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                return cmd.ExecuteNonQuery();
            }
        }

        public object LayGiaTri(string sql)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                return cmd.ExecuteScalar();
            }
        }
    }
}
