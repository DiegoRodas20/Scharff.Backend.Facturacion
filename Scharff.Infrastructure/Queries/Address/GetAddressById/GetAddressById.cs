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
                    string sql = @"SELECT 
                                    a.id
                                    ,a.type_param
                                    ,a.unit_id
                                    ,a.address
                                    ,a.postal_code
                                    ,u.code as ubigeo_code_description
                                    ,pro.id as province_id
                                    ,a.ubigeo_id as district_id
                                    ,a.status
	                               FROM nsf.address  a
	                               LEFT JOIN nsf.ubigeo u ON u.id=a.ubigeo_id
	                               LEFT JOIN nsf.ubigeo pro ON pro.id=u.parent_id
	                               LEFT JOIN nsf.parameter_detail p ON p.id=a.type_param
	                               LEFT JOIN nsf.ubigeo dep ON dep.id=pro.parent_id
                                   WHERE a.id = @id";
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
