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

namespace Scharff.Infrastructure.Repositories.Contact.DeleteContact
{
    public class DeleteContactRepository : IDeleteContactRepository
    {
        private readonly IDbConnection _connection;

        public DeleteContactRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public async Task<ResponseModel> DeleteContact(int Id)
        {
            using (TransactionScope trans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            using (IDbConnection connection = new NpgsqlConnection(_connection.ConnectionString))
            {
                try
                {

                    string delete = @"  DELETE  
                                        FROM CONTACTO
                                        WHERE 
                                        Id= @Id ;";

                    int hasDelete = await connection.ExecuteAsync(delete, Id);
                    if (hasDelete <= 0)
                        Handlers.ExceptionClose(connection, "Ocurrió un error al eliminar el contacto");

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
