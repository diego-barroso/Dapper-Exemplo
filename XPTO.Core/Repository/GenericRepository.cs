using System.Collections.Generic;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace XPTO.Core.Repository
{
    public static class GenericRepository
    {
        private static readonly string connectionString = ConfigurationManager.AppSettings.Get("XPTO.ConnectionString");

        public static void ExecutarStoredProcedure(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                con.Execute(procedureName, param, commandType: CommandType.StoredProcedure);
            }
        }

        public static IEnumerable<T> ExecutarQuery<T>(string query)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                return con.Query<T>(query);
            }
        }
    }
}