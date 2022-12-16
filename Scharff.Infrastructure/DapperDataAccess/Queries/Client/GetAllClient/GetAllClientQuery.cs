using Dapper;
using Npgsql;
using Scharff.Domain.Entities;
using System.Data;

namespace Scharff.Infrastructure.DapperDataAccess.Queries.Client.GetAllClient
{
    public class GetAllClientQuery : IGetAllClientQuery
    {
        private readonly string _connection;

        public GetAllClientQuery(string connection)
        {
            _connection = connection;
        }

        public async Task<ClientModel> GetAllClient()
        {
            using (IDbConnection connection = new NpgsqlConnection(_connection))
            {
                string sql = @"SELECT * FROM CLIENT";

                ClientModel client = (ClientModel)await connection.QueryAsync<ClientModel>(sql);
                return client;
            }
        }
    }
}
