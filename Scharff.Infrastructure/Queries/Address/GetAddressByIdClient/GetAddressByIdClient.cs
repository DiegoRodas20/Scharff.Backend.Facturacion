using Dapper;
using Npgsql;
using Scharff.Domain.Entities;
using System.Data;


namespace Scharff.Infrastructure.Queries.Address.GetAddressByIdClient
{
    public class GetAddressByIdClient: IGetAddressByIdClient
    {
        private readonly IDbConnection _connection;

        public GetAddressByIdClient(IDbConnection connection)
        {
            _connection = connection;
        }
        public async Task<List<AddressModel>> GetDirectionByIdClient(int idClient)
        {
            using (IDbConnection connection = new NpgsqlConnection(_connection.ConnectionString))
            {
                try
                {
                    string sql = @"SELECT * FROM nsf.address WHERE ""client_id"" = @idClient";
                    var queryArgs = new { idClient };
                    IEnumerable<AddressModel> direction = await connection.QueryAsync<AddressModel>(sql, queryArgs);
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
