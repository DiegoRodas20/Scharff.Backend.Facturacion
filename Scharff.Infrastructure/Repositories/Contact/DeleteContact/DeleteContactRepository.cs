using Dapper;
using Npgsql;
using System.Data;
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
        public async Task<int> DeleteContact(int Id)
        {
            using (TransactionScope trans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            using (IDbConnection connection = new NpgsqlConnection(_connection.ConnectionString))
            {
                try
                {

                    string delete = @"  DELETE  
                                        FROM nsf.contact
                                        WHERE 
                                        id= @Id ;";

                    var queryArgs = new { Id };


                    int hasDelete = await connection.ExecuteAsync(delete, queryArgs);
                    trans.Complete();

                    return hasDelete;
                }
                catch (NpgsqlException err)
                {
                    throw err;
                }
            }

        }
    }
}
