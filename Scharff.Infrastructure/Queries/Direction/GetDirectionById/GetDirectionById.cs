using Dapper;
using Npgsql;
using Scharff.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Scharff.Infrastructure.Queries.Direction.GetDirectionById
{
    public class GetDirectionById : IGetDirectionById
    {
        private readonly IDbConnection _connection;

        public GetDirectionById(IDbConnection connection)
        {
            _connection = connection;
        }
        public async Task<DirectionModel> GetDirectionByID(int id)
        {
            using (IDbConnection connection = new NpgsqlConnection(_connection.ConnectionString))
            {
                try
                {
                    string sql = @"SELECT * FROM DIRECCION WHERE id = @id";

                    DirectionModel direction = await connection.QuerySingleAsync<DirectionModel>(sql, id);
                    return direction;
                }
                catch (NpgsqlException err)
                {
                    throw err;
                }
            }
        }
    }
}
