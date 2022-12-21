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
        public async Task<ResponseModel> RegisterClient(ClientModel cliente)
        {
            using (TransactionScope trans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            using (IDbConnection connection = new NpgsqlConnection(_connection.ConnectionString))
            {
                try
                {
                    string insert = @"  INSERT INTO CLIENTE 
                                            tipoDocumentoIdentidad, 
                                            numeroDocumentoIdentidad,
                                            razonSocial,
                                            telefono,
                                            nombreComercial,
                                            tipoMoneda_parametro,
                                            grupoEmpresarial_parametro,
                                            codigoSector_parametro,
                                            holding_parametro,
                                            codigoSegmentacion_parametro
                                        VALUES 
                                            @TypeDocumentIdentity, 
                                            @NumberDocumentIdentity, 
                                            @CompanyName, 
                                            @Phone, 
                                            @TradeName, 
                                            @TypeCurrency, 
                                            @BusinessGroup, 
                                            @CodeEconomicSector,
                                            @Holding,                                            
                                            @CodeSegmentation;";

                    int hasInsert = await connection.ExecuteAsync(insert, cliente);
                    if (hasInsert <= 0)
                        Handlers.ExceptionClose(connection, "Ocurrió un error al insertar el cliente");

                    return Handlers.CloseConnection(connection, trans, "Registro exitoso");
                }
                catch (NpgsqlException err)
                {
                    throw err;
                }
            }
        }
    }
}
