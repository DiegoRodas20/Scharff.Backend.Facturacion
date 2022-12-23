using Dapper;
using JKM.UTILITY.Utils;
using Npgsql;
using Scharff.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Scharff.Infrastructure.Repositories.Direction.RegisterDirection
{
    public   class RegisterDirectionRepository : IRegisterDirectionRepository
    {
        private readonly IDbConnection _connection;

        public RegisterDirectionRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public async Task<ResponseModel> RegisterDirection(DirectionModel direction)
        {
            using (TransactionScope trans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            using (IDbConnection connection = new NpgsqlConnection(_connection.ConnectionString))
            {
                try
                {

        string insert = @"  INSERT INTO DIRECCION 
                                            estado, 
                                            tipoDireccion_parametro,
                                            idCliente,
                                            idUbigeo,
                                            direccion,
                                            codigoPostal,
                                            fechaCreacion,
                                            autorCreacion,
                                            fechaModificacion,
                                            autorModificacion
                                        VALUES 
                                            @Status, 
                                            @TypeDirectionParameter, 
                                            @IdClient, 
                                            @IdUbigeo, 
                                            @Direction, 
                                            @PostalCode, 
                                            @CreationDate,
                                            @AuthorCreation,                                            
                                            @DateUpdate,
                                            @AuthorUpdate;
                                            ";

                    int hasInsert = await connection.ExecuteAsync(insert, direction);
                    if (hasInsert <= 0)
                        Handlers.ExceptionClose(connection, "Ocurrió un error al insertar la direccion");

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
