using Dapper;
using JKM.UTILITY.Utils;
using Npgsql;
using Scharff.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Scharff.Infrastructure.Repositories.Direction.DeleteDirection
{
    public class DeleteDirectionRepository : IDeleteDirectionRepository
    {
        private readonly IDbConnection _connection;

        public DeleteDirectionRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public async Task<ResponseModel> DeleteDirection(int Id)
        {
            using (TransactionScope trans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            using (IDbConnection connection = new NpgsqlConnection(_connection.ConnectionString))
            {
                try
                {

                    string delete = @"  DELETE  
                                        FROM DIRECCION
                                        WHERE 
                                        Id= @Id ;";

                    int hasDelete = await connection.ExecuteAsync(delete, Id);
                    if (hasDelete <= 0)
                        Handlers.ExceptionClose(connection, "Ocurrió un error al eliminar la direccion");

                    return Handlers.CloseConnection(connection, trans, "Eliminar exitoso");
                }
                catch (NpgsqlException err)
                {
                    throw err;
                }
            }
        }
    }
}
