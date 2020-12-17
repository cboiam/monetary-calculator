using System.Data;
using Microsoft.Extensions.Configuration;

namespace MonetaryCalculator.Infra.Data
{
    public interface IPostgresConnection
    {
        IDbConnection GetConnection(IConfiguration configuration);
    }
}
