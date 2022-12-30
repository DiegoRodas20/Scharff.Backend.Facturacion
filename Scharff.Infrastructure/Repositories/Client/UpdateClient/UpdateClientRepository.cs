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
                    //string insert = $@"UPDATE 
                    //                     public.cliente SET
                    //                        ""tipoDocumentoIdentidad"" = @tipoDocumentoIdentidad, 
                    //                        ""numeroDocumentoIdentidad"" = @numeroDocumentoIdentidad,
                    //                        ""razonSocial"" = @razonSocial,
                    //                        ""telefono"" = @telefono,
                    //                        ""nombreComercial"" = @nombreComercial,
                    //                        ""tipoMoneda_parametro"" = @tipoMoneda_parametro,
                    //                        ""grupoEmpresarial_parametro"" = @grupoEmpresarial_parametro,
                    //                        ""codigoSector_parametro"" = @codigoSector_parametro,
                    //                        ""holding_parametro"" = @holding_parametro,
                    //                        ""codigoSegmentacion_parametro"" = @codigoSegmentacion_parametro,
                    //                        ""comentario"" = @comentario
                    //                    WHERE
                    //                        id = @id";

                    string insert = $@"UPDATE 
                                         nsf.client SET
                                            document_type_id = @document_type_id, 
                                            identity_document_number = @identity_document_number,
                                            business_name = @business_name,
                                            telephone = @telephone,
                                            commercial_name = @commercial_name,
                                            currency_type = @currency_type,
                                            corporate_group_param = @corporate_group_param,
                                            industry_code_param = @industry_code_param,
                                            holding_param = @holding_param,
                                            segmentation_code_param = @segmentation_code_param,
                                            comment = @comment
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
