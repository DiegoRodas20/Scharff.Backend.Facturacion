using Dapper;
using Npgsql;
using System.Data;

namespace Scharff.Infrastructure.Repositories.Client.DisableClient
{
    public class DisableClientRepository : IDisableClientRepository
    {
        private readonly IDbConnection _connection;

        public DisableClientRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> DisableClient(int idClient)
        {
            using (IDbConnection connection = new NpgsqlConnection(_connection.ConnectionString))
            {
                try {
                    string update = $@"UPDATE 
                                         public.cliente SET
                                            ""estadoCliente"" = false
                                         WHERE
                                            id = @idClient";

                    var queryArgs = new { idClient };

                    int hasUpdate = await connection.ExecuteAsync(update, queryArgs);
                    return hasUpdate;
                }
                catch (NpgsqlException err)
                {
                    throw err;
                }
            }
        }
    }
}
