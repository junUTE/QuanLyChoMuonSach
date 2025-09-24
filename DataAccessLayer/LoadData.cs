using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public static class LoadData
    {
        private static string connectionString =
        "Data Source=.;Initial Catalog=QLThuVien;Integrated Security=True;TrustServerCertificate=True";

        public static void SetConnectionString(string connStr)
        {
            connectionString = connStr;
        }

        public static string GetConnectionString()
        {
            return connectionString;
        }

        public static DataTable ExecuteQuery(string sql, object[] parameters = null)
        {
            var dt = new DataTable();
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null)
                    for (int i = 0; i < parameters.Length; i++)
                        cmd.Parameters.AddWithValue($"@param{i}", parameters[i] ?? DBNull.Value);

                new SqlDataAdapter(cmd).Fill(dt);
            }
            return dt;
        }

        // --- Overload gọi Stored Procedure với SqlParameter[] ---
        public static DataTable ExecuteQuerySP(string spName, params SqlParameter[] prms)
        {
            var dt = new DataTable();
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(spName, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (prms != null && prms.Length > 0) cmd.Parameters.AddRange(prms);
                new SqlDataAdapter(cmd).Fill(dt);
            }
            return dt;
        }

        public static int ExecuteNonQuerySP(string spName, params SqlParameter[] prms)
        {
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(spName, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (prms != null && prms.Length > 0) cmd.Parameters.AddRange(prms);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static object ExecuteScalarSP(string spName, params SqlParameter[] prms)
        {
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(spName, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (prms != null && prms.Length > 0) cmd.Parameters.AddRange(prms);
                conn.Open();
                return cmd.ExecuteScalar();
            }
        }
    }
}
