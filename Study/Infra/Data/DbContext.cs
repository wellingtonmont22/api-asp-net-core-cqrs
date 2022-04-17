using MySqlConnector;
using System.Data;

namespace Study.Infra.Data
{
    public class DbContext : IDisposable
    {
        public IDbConnection Connection { get; }

        public DbContext(IConfiguration configuration)
        {
            Connection = new MySqlConnection(configuration.GetConnectionString("mysqldb"));
            Connection.Open();
        }
        public void Dispose() => Connection?.Dispose();

    }
}
