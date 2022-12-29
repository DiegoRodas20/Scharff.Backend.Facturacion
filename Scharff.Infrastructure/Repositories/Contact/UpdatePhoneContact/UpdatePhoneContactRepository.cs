using Dapper;
using Npgsql;
using Scharff.Domain.Entities;
using System.Data;
using System.Transactions;

namespace Scharff.Infrastructure.Repositories.Contact.UpdatePhoneContact
{
    public class UpdatePhoneContactRepository : IUpdatePhoneContactRepository
    {
        private readonly IDbConnection _connection;

        public UpdatePhoneContactRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> UpdatePhoneContact(PhoneContactModel telefonocontacto)
        {

            using (TransactionScope trans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            using (IDbConnection connection = new NpgsqlConnection(_connection.ConnectionString))
            {
                try
                {
                    string update = @"  UPDATE public.telefono_contacto 
                                        SET  
                                            ""telefono"" = @telefono,
                                            ""fechaModificacion"" = @fechaModificacion
                                        WHERE 
                                            Id= @Id ;";

                    int hasUpdate = await connection.ExecuteAsync(update, telefonocontacto);
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
