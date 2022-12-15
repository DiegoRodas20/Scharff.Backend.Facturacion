using Dapper;
using Npgsql;
using Scharff.Domain.Entities;
using System.Data;

namespace Scharff.Infrastructure.DapperDataAccess.Queries.Client.GetClientById
{
    public class GetClientByIdQuery : IGetClientByIdQuery
    {
        private readonly string _connection;

        public GetClientByIdQuery(string connection)
        {
            _connection = connection;
        }

        public async Task<ClientModel> GetClientById(int idClient)
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
