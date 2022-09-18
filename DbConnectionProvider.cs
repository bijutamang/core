using System.Data;
using System.Data.SqlClient;
namespace coresystem
{
    public class DbConnectionProvider : IDbConnectionProvider
    {
        private string _connectionString = @"server=BHX\BHXBA; database=CoreSystem; user=sa; password=Bb(_22;";

        public IDbConnection GetConnection() => new SqlConnection(_connectionString);
    }
}
