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
    public class GetContactById : IGetContactById
    {
        private readonly IDbConnection _connection;

        public GetContactById(IDbConnection connection)
        {
            _connection = connection;
        }
        public async Task<ContactModel> GetContactByID(int idClient)
        {
            using (IDbConnection connection = new NpgsqlConnection(_connection.ConnectionString))
            {
                try
                {
                    string sql = @"SELECT * FROM CONTACTO WHERE id = @IdClient";

                    ContactModel contact = await connection.QuerySingleAsync<ContactModel>(sql, idClient);

                    return contact;
                }
                catch (NpgsqlException err)
                {
                    throw err;
                }
            }
        }
    }
}
