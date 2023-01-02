using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scharff.Infrastructure.Repositories.Client.EnableClient
{
    public class EnableClientRepository : IEnableClientRepository
    {
        private readonly IDbConnection _connection;

        public EnableClientRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> EnableClient(int idClient)
        {
            using (IDbConnection connection = new NpgsqlConnection(_connection.ConnectionString))
            {
                try
                {
                    //string update = $@"UPDATE 
                    //                     public.cliente SET
                    //                        ""estadoCliente"" = true
                    //                     WHERE
                    //                        id = @idClient";

                    string update = $@"UPDATE 
                                         nsf.client SET
                                            status = true
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
