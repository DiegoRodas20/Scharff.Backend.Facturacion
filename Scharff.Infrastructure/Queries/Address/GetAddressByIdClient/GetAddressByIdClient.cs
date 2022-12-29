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
        public async Task<List<DirectionModel>> GetDirectionByIdClient(int idClient)
        {
            using (IDbConnection connection = new NpgsqlConnection(_connection.ConnectionString))
            {
                try
                {
                    string sql = @"SELECT * FROM DIRECCION WHERE ""idCliente"" = @idClient";
                    var queryArgs = new { idClient };
                    IEnumerable<DirectionModel> direction = await connection.QueryAsync<DirectionModel>(sql, queryArgs);
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
