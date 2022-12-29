using Dapper;
using JKM.UTILITY.Utils;
using Npgsql;
using Scharff.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Scharff.Infrastructure.Repositories.Direction.UpdateDirection
{
    public class UpdateDirectionRepository : IUpdateDirectionRepository
    {
        private readonly IDbConnection _connection;

        public UpdateDirectionRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public async Task<ResponseModel> UpdateDirection(AddressModel direction)
        {
            using (TransactionScope trans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            using (IDbConnection connection = new NpgsqlConnection(_connection.ConnectionString))
            {
                try
                {

                    string update = @"  UPDATE DIRECCION 
                                        SET 
                                            ""tipoDireccion_parametro"" = @TypeDirectionParameter,                                            
                                            ""idUbigeo"" = @IdUbigeo,
                                            ""direccion"" = @Direction,
                                            ""codigoPostal"" = @PostalCode,                                            
                                            ""fechaModificacion"" = @DateUpdate,
                                            ""autorModificacion"" = @AuthorUpdate
                                        WHERE 
                                            Id= @Id ;";

                    int hasUpdate = await connection.ExecuteAsync(update, direction);
                    if (hasUpdate <= 0)
                        Handlers.ExceptionClose(connection, "Ocurrió un error al actualizar la direccion");

                    return Handlers.CloseConnection(connection, trans, "Actualizar exitoso");
                }
                catch (NpgsqlException err)
                {
                    throw err;
                }
            }
        }
    }
}
