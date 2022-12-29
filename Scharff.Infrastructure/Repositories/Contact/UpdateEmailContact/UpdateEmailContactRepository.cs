using Dapper;
using Npgsql;
using Scharff.Domain.Entities;
using System.Data;
using System.Transactions;

namespace Scharff.Infrastructure.Repositories.Contact.UpdateEmailContact
{
    public class UpdateEmailContactRepository : IUpdateEmailContactRepository
    {
        private readonly IDbConnection _connection;

        public UpdateEmailContactRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> UpdateEmailContact(EmailContactModel emailcontacto)
        {
            using (TransactionScope trans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            using (IDbConnection connection = new NpgsqlConnection(_connection.ConnectionString))
            {
                try
                {
                    string update = @"  UPDATE public.email_contacto 
                                        SET  
                                            ""email"" = @email,
                                            ""fechaModificacion"" = @fechaModificacion
                                        WHERE 
                                            Id= @Id ;";

                    int hasUpdate = await connection.ExecuteAsync(update, emailcontacto);
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
