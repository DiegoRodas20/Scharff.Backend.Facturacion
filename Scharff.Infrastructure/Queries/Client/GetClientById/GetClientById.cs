using Dapper;
using Npgsql;
using Scharff.Domain.Entities;
using System.Data;

namespace Scharff.Infrastructure.Queries.Client.GetClientById
{
    public class GetClientById : IGetClientById
    {
        private readonly IDbConnection _connection;

        public GetClientById(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<ClientModel> GetClientByID(int idClient)
        {
            using (IDbConnection connection = new NpgsqlConnection(_connection.ConnectionString))
            {
                try
                {
                    string sql = @"SELECT * FROM CLIENTE WHERE id = @IdClient";

                    ClientModel client = await connection.QuerySingleAsync<ClientModel>(sql, idClient);
                    return client;
                }
                catch (NpgsqlException err)
                {
                    throw err;
                }
            }
        }
    }
}
