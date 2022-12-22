using Dapper;
using JKM.UTILITY.Utils;
using Npgsql;
using Scharff.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<ResponseModel> UpdateContact(ContactModel contacto)
        {
            using (TransactionScope trans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            using (IDbConnection connection = new NpgsqlConnection(_connection.ConnectionString))
            {
                try
                {

        string update = @"  UPDATE CONTACTO 
                                        SET estado = Status, 
                                            idCliente = @IdClient,
                                            tipoContacto_parametro = @TypeContactParameter,
                                            areaContacto_parametro = @AreaContactParameter,
                                            nombreCompleto = @FullName,
                                            comentario = @Commentary,
                                            fechaCreacion = @CreationDate ,
                                            autorCreacion = @AuthorCreation,
                                            fechaActualizacion = @DateUpdate,
                                            autorActualizacion = @AuthorUpdate
                                            fechaInicio = @StartDate
                                            fechaFin = @EndDate
                                        WHERE 
                                            Id= @Id ;";

                    int hasUpdate = await connection.ExecuteAsync(update, contacto);
                    if (hasUpdate <= 0)
                        Handlers.ExceptionClose(connection, "Ocurrió un error al actualizar el contacto");

                    return Handlers.CloseConnection(connection, trans, "Actualizar exitoso");
                }
                catch (NpgsqlException err)
                {
                    throw err;
                }
            }

        }
    }
    
}
