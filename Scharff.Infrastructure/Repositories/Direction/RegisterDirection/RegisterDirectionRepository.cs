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
        public async Task<int> RegisterDirection(DirectionModel direction)
        {
            using (TransactionScope trans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            using (IDbConnection connection = new NpgsqlConnection(_connection.ConnectionString))
            {
                try
                {

                    string insert = @"  INSERT INTO DIRECCION 
                                            (""tipoDireccion_parametro"",
                                            ""idCliente"",
                                            ""direccion"")
                                        VALUES 
                                            (@TypeDirectionParameter, 
                                            @IdClient,
                                            @Direction) RETURNING Id;";

                    int idInsert = await connection.ExecuteScalarAsync<int>(insert, direction);
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
