using Dapper;
using Npgsql;
using Scharff.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scharff.Infrastructure.Queries.Contact.GetContactById
{
    public class GetContactByIdQuery : IGetContactByIdQuery
    {
        private readonly IDbConnection _connection;

        public GetContactByIdQuery(IDbConnection connection)
        {
            _connection = connection;
        }
        public async Task<List<ContactModel>> GetContactById(int idClient)
        {
            using (IDbConnection connection = new NpgsqlConnection(_connection.ConnectionString))
            {
                try
                {
                    string sql = @"SELECT 
                                        * 
                                   FROM 
                                      CONTACTO 
                                   WHERE 
                                      ""idCliente"" = @idClient";

                    var queryArgs = new { idClient };

                    IEnumerable<ContactModel> contact = await connection.QueryAsync<ContactModel>(sql, queryArgs);

                    return contact.ToList();
                }
                catch (NpgsqlException err)
                {
                    throw err;
                }
            }
        }
    }
}
