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
        public async Task<List<AddressModel>> GetDirectionByID(int id)
        {
            using (IDbConnection connection = new NpgsqlConnection(_connection.ConnectionString))
            {
                try
                {
                    string sql = @"SELECT * FROM nsf.address WHERE ""id"" = @id";
                    var queryArgs = new { id };
                    IEnumerable <AddressModel> direction = await connection.QueryAsync<AddressModel>(sql, queryArgs);
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
