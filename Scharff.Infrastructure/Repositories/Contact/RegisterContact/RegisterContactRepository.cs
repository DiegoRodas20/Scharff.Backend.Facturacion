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

namespace Scharff.Infrastructure.Repositories.Contact.RegisterContact
{
    public class RegisterContactRepository : IRegisterContactRepository
    {
        private readonly IDbConnection _connection;

        public RegisterContactRepository(IDbConnection connection)
        {
            _connection = connection;
        }


        public async Task<ResponseModel> RegisterContact(ContactModel contacto)
        {

            using (TransactionScope trans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            using (IDbConnection connection = new NpgsqlConnection(_connection.ConnectionString))
            {
                try
                {

        string insert = @"  INSERT INTO CONTACTO 
                                            estado, 
                                            idCliente,
                                            tipoContacto_parametro,
                                            areaContacto_parametro,
                                            nombreCompleto,
                                            comentario,
                                            fechaCreacion,
                                            autorCreacion,
                                            fechaActualizacion,
                                            autorActualizacion
                                            fechaInicio
                                            fechaFin
                                        VALUES 
                                            @Status, 
                                            @IdClient, 
                                            @TypeContactParameter, 
                                            @AreaContactParameter, 
                                            @FullName, 
                                            @Commentary, 
                                            @CreationDate, 
                                            @AuthorCreation,
                                            @DateUpdate,                                            
                                            @AuthorUpdate,
                                            @StartDate,
                                            @EndDate;";

                    int hasInsert = await connection.ExecuteAsync(insert, contacto);
                    if (hasInsert <= 0)
                        Handlers.ExceptionClose(connection, "Ocurrió un error al insertar el contacto");

                    return Handlers.CloseConnection(connection, trans, "Registro exitoso");
                }
                catch (NpgsqlException err)
                {
                    throw err;
                }
            }

        }
    }
}
