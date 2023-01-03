using Dapper;
using Npgsql;
using Scharff.Domain.Entities;
using System.Data;
using System.Transactions;

namespace Scharff.Infrastructure.Repositories.Contact.RegisterContact
{
    public class RegisterContactRepository : IRegisterContactRepository
    {
        private readonly IDbConnection _connection;

        public RegisterContactRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> RegisterContact(ContactModel contacto)
        {

            using (TransactionScope trans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            using (IDbConnection connection = new NpgsqlConnection(_connection.ConnectionString))
            {
                try
                {

                    string insert = @"  INSERT INTO nsf.contact 
                                           (""status"", 
                                            ""client_id"",
                                            ""type_param"",
                                            ""area_param"",
                                            ""full_name"",
                                            ""comment"",
                                            ""creation_date"",
                                            ""start_date""
                                            )
                                        VALUES 
                                            (@status, 
                                            @client_id, 
                                            @type_param, 
                                            @area_param, 
                                            @full_name, 
                                            @comment,
                                            @creation_date,
                                            @start_date
                                            ) 
                                            RETURNING Id;";

                    int idInsert = await connection.ExecuteScalarAsync<int>(insert, contacto);
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
