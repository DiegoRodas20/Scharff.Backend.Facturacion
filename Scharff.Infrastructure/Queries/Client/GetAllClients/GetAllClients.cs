using Dapper;
using Npgsql;
using Scharff.Domain.Entities;
using System.Data;

namespace Scharff.Infrastructure.Queries.Client.GetAllClients
{
    public class GetAllClients : IGetAllClients
    {
        private readonly IDbConnection _connection;

        public GetAllClients(IDbConnection connection)
        {
            _connection = connection;
        }
        public async Task<List<ClientModel>> GetAllClient()
        {
            using (IDbConnection connection = new NpgsqlConnection(_connection.ConnectionString))
            {
                try
                {
                    string sql = @"SELECT * FROM nsf.client";

                    IEnumerable<ClientModel> clients = await connection.QueryAsync<ClientModel>(sql);
                    return clients.ToList();
                }
                catch (NpgsqlException err)
                {
                    throw err;
                }
            }
        }
    }
}
