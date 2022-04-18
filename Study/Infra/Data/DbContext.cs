using MySql.Data.MySqlClient;

namespace Study.Infra.Data
{
    public class DbContext : IAsyncDisposable
    {
        public MySqlConnection Connection { get; set; }

        public DbContext(IConfiguration configuration)
        {
            Connection = new MySqlConnection(configuration.GetConnectionString("mysqldb"));
            Connection.Open();
        }

        public async ValueTask DisposeAsync()
        {
            await Connection.CloseAsync();
            await Connection.ClearAllPoolsAsync();
            await Connection.DisposeAsync();
        }
    }
}
