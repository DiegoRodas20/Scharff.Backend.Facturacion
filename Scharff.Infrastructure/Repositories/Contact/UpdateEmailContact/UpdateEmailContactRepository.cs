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
                    string update = @"  UPDATE nsf.email_contact 
                                        SET  
                                            ""email"" = @email,
                                            ""modification_date"" = @modification_date
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
