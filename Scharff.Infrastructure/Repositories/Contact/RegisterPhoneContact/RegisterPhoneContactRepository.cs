using Dapper;
using Npgsql;
using Scharff.Domain.Entities;
using System.Data;
using System.Transactions;

namespace Scharff.Infrastructure.Repositories.Contact.RegisterPhoneContact
{
    public class RegisterPhoneContactRepository : IRegisterPhoneContactRepository
    {
        private readonly IDbConnection _connection;

        public RegisterPhoneContactRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> RegisterPhoneContact(PhoneContactModel telefonoscontacto)
        {
            using (TransactionScope trans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            using (IDbConnection connection = new NpgsqlConnection(_connection.ConnectionString))
            {
                try
                {
                    string insert = @"  INSERT INTO public.telefono_contacto 
                                           (""telefono"", 
                                            ""idContacto"",
                                            ""fechaCreacion""
                                            )
                                        VALUES 
                                            (@telefono, 
                                            @idContacto, 
                                            @fechaCreacion
                                            ) 
                                            RETURNING Id;"
                    ;

                    int idInsert = await connection.ExecuteScalarAsync<int>(insert, telefonoscontacto);
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
