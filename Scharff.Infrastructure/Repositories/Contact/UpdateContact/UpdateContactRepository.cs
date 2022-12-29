using Dapper;
using Npgsql;
using Scharff.Domain.Entities;
using System.Data;
using System.Transactions;

namespace Scharff.Infrastructure.Repositories.Contact.UpdateContact
{
    public class UpdateContactRepository : IUpdateContactRepository
    {
        private readonly IDbConnection _connection;

        public UpdateContactRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> UpdateContact(ContactModel contacto)
        {
            using (TransactionScope trans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            using (IDbConnection connection = new NpgsqlConnection(_connection.ConnectionString))
            {
                try
                {
                    string update = @"  UPDATE public.contacto 
                                        SET                                             
                                            ""tipoContacto_parametro"" = @tipoContacto_parametro,
                                            ""areaContacto_parametro"" = @areaContacto_parametro,
                                            ""nombreCompleto"" = @nombreCompleto,
                                            ""comentario"" = @comentario,
                                            ""fechaActualizacion"" = @fechaActualizacion
                                        WHERE 
                                            Id= @Id ;";

                    int hasUpdate = await connection.ExecuteAsync(update, contacto);
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
