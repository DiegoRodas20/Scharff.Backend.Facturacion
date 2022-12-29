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



                    string insert = @"  INSERT INTO public.contacto 
                                           (""estado"", 
                                            ""idCliente"",
                                            ""tipoContacto_parametro"",
                                            ""areaContacto_parametro"",
                                            ""nombreCompleto"",
                                            ""comentario"",
                                            ""fechaCreacion"",
                                            ""fechaInicio""
                                            )
                                        VALUES 
                                            (@estado, 
                                            @idCliente, 
                                            @tipoContacto_parametro, 
                                            @areaContacto_parametro, 
                                            @nombreCompleto, 
                                            @comentario,
                                            @fechaCreacion,
                                            @fechaInicio
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
