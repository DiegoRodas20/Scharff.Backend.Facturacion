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

        public async Task<int> RegisterContact(ContactModel contacto)
        {

            using (TransactionScope trans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            using (IDbConnection connection = new NpgsqlConnection(_connection.ConnectionString))
            {
                try
                {

                    string insert = @"  INSERT INTO CONTACTO 
                                           (""estado"", 
                                            ""idCliente"",
                                            ""tipoContacto_parametro"",
                                            ""areaContacto_parametro"",
                                            ""nombreCompleto"",
                                            ""comentario"")
                                        VALUES 
                                            (true, 
                                            @idCliente, 
                                            @tipoContacto_parametro, 
                                            @areaContacto_parametro, 
                                            @nombreCompleto, 
                                            @comentario) RETURNING Id;";

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
