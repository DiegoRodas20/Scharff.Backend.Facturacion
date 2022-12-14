using Dapper;
using JKM.UTILITY.Utils;
using Npgsql;
using Scharff.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Scharff.Infrastructure.Repositories.Client.RegisterClient
{
    public class RegisterClientRepository : IRegisterClientRepository
    {
        private readonly IDbConnection _connection;

        public RegisterClientRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public async Task<int> RegisterClient(ClientModel cliente)
        {
            using (TransactionScope trans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            using (IDbConnection connection = new NpgsqlConnection(_connection.ConnectionString))
            {
                try
                {
                    //string insert = @"INSERT INTO public.cliente 
                    //                        (""tipoDocumentoIdentidad"", 
                    //                        ""numeroDocumentoIdentidad"",
                    //                        ""razonSocial"",
                    //                        ""telefono"",
                    //                        ""nombreComercial"",
                    //                        ""tipoMoneda_parametro"",
                    //                        ""grupoEmpresarial_parametro"",
                    //                        ""codigoSector_parametro"",
                    //                        ""holding_parametro"",
                    //                        ""codigoSegmentacion_parametro"",
                    //                        ""comentario"")
                    //                    VALUES 
                    //                        (@tipoDocumentoIdentidad, 
                    //                        @numeroDocumentoIdentidad, 
                    //                        @razonSocial, 
                    //                        @telefono, 
                    //                        @nombreComercial, 
                    //                        @tipoMoneda_parametro, 
                    //                        @grupoEmpresarial_parametro, 
                    //                        @codigoSector_parametro,
                    //                        @holding_parametro,                                            
                    //                        @codigoSegmentacion_parametro,
                    //                        @comentario) RETURNING Id;";

                    string insert = @"INSERT INTO nsf.client
                                            (document_type_id, 
                                            identity_document_number,
                                            business_name,
                                            telephone,
                                            commercial_name,
                                            currency_type,
                                            corporate_group_param,
                                            industry_code_param,
                                            holding_param,
                                            segmentation_code_param,
                                            comment)
                                        VALUES 
                                            (@document_type_id, 
                                            @identity_document_number, 
                                            @business_name, 
                                            @telephone, 
                                            @commercial_name, 
                                            @currency_type, 
                                            @corporate_group_param, 
                                            @industry_code_param,
                                            @holding_param,                                            
                                            @segmentation_code_param,
                                            @comment) RETURNING Id;";

                    int idInsert = await connection.ExecuteScalarAsync<int>(insert, cliente);
                    trans.Complete();
                    return idInsert;
                }
                catch (NpgsqlException err)
                {
                    throw err;
                }
            }
        }
    }
}
