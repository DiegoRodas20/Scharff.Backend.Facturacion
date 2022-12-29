using Dapper;
using Npgsql;
using Scharff.Domain.Entities;
using System.Data;
using System.Net.Sockets;


namespace Scharff.Infrastructure.Queries.Direction.GetDirectionById
{
    public class GetAddressById : IGetAddressById
    {
        private readonly IDbConnection _connection;

        public GetAddressById(IDbConnection connection)
        {
            _connection = connection;
        }
        public async Task<List<DirectionModel>> GetDirectionByID(int id)
        {
            using (IDbConnection connection = new NpgsqlConnection(_connection.ConnectionString))
            {
                try
                {
                    string sql = @"SELECT * FROM DIRECCION WHERE ""id"" = @id";
                    var queryArgs = new { id };
                    IEnumerable <DirectionModel> direction = await connection.QueryAsync<DirectionModel>(sql, queryArgs);
                    return direction.ToList();
                }
                catch (NpgsqlException err)
                {
                    throw err;
                }
            }
        }
    }
}
