using Dapper;
using Npgsql;
using Scharff.Domain.Entities;
using System.Data;
using System.Transactions;

namespace Scharff.Infrastructure.Repositories.Client.UpdateClient
{
    public class UpdateClientRepository : IUpdateClientRepository
    {
        private readonly IDbConnection _connection;

        public UpdateClientRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public async Task<int> UpdateClient(ClientModel client)
        {
            using (TransactionScope trans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            using (IDbConnection connection = new NpgsqlConnection(_connection.ConnectionString))
            {
                try
                {
                    string insert = $@"UPDATE 
                                         public.cliente SET
                                            ""tipoDocumentoIdentidad"" = @tipoDocumentoIdentidad, 
                                            ""numeroDocumentoIdentidad"" = @numeroDocumentoIdentidad,
                                            ""razonSocial"" = @razonSocial,
                                            ""telefono"" = @telefono,
                                            ""nombreComercial"" = @nombreComercial,
                                            ""tipoMoneda_parametro"" = @tipoMoneda_parametro,
                                            ""grupoEmpresarial_parametro"" = @grupoEmpresarial_parametro,
                                            ""codigoSector_parametro"" = @codigoSector_parametro,
                                            ""holding_parametro"" = @holding_parametro,
                                            ""codigoSegmentacion_parametro"" = @codigoSegmentacion_parametro,
                                            ""comentario"" = @comentario
                                        WHERE
                                            id = @id";
                    int hasUpdate = await connection.ExecuteAsync(insert, client);
                    trans.Complete();
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
