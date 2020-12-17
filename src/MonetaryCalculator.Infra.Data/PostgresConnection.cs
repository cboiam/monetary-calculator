using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace MonetaryCalculator.Infra.Data
{
    public class PostgresConnection : IPostgresConnection
    {
        public IDbConnection GetConnection(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("default");
            return new NpgsqlConnection(connectionString);
        }
    }
}
