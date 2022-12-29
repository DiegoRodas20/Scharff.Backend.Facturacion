using Dapper;
using Npgsql;
using System.Data;
using System.Transactions;

namespace Scharff.Infrastructure.Repositories.Contact.DeleteEmailContact
{
    public class DeleteEmailContactRepository : IDeleteEmailContactRepository
    {
        private readonly IDbConnection _connection;

        public DeleteEmailContactRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public async Task<int> DeleteEmailContact(int IdContacto)
        {
            using (TransactionScope trans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            using (IDbConnection connection = new NpgsqlConnection(_connection.ConnectionString))
            {
                try
                {



                    string delete = @" DELETE  
                                       FROM public.email_contacto
                                       WHERE 
                                       ""idContacto""= @IdContacto ;"
                    ;


                    var queryArgs = new { IdContacto };

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
