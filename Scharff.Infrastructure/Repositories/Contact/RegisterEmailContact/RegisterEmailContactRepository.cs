using Dapper;
using Npgsql;
using Scharff.Domain.Entities;
using System.Data;
using System.Transactions;

namespace Scharff.Infrastructure.Repositories.Contact.RegisterEmailContact
{
    public class RegisterEmailContactRepository : IRegisterEmailContactRepository
    {
        private readonly IDbConnection _connection;

        public RegisterEmailContactRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> RegisterEmailContact(EmailContactModel emailscontacto)
        {

            using (TransactionScope trans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            using (IDbConnection connection = new NpgsqlConnection(_connection.ConnectionString))
            {
                try
                {
                    string insert = @"  INSERT INTO public.email_contacto 
                                           (""email"", 
                                            ""idContacto"",
                                            ""fechaCreacion""
                                            )
                                        VALUES 
                                            (@email, 
                                            @idContacto, 
                                            @fechaCreacion
                                            ) 
                                            RETURNING Id;"
                    ;

                    int idInsert = await connection.ExecuteScalarAsync<int>(insert, emailscontacto);
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
