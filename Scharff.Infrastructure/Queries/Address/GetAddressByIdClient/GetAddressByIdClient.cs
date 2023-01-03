using Dapper;
using Npgsql;
using Scharff.Domain.Entities;
using System.Data;


namespace Scharff.Infrastructure.Queries.Address.GetAddressByIdClient
{
    public class GetAddressByIdClient : IGetAddressByIdClient
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
                    string sql = @" SELECT 
                                            a.id
                                            ,a.address
                                            ,a.postal_code
                                            ,u.code as ubigeo_code_description
                                            ,pro.description as province_description
                                            ,p.description as address_type_description
                                            ,dep.description as department_description
                                            ,a.status
                                            ,u.description  as district_description
	                                FROM nsf.address  a
	                                LEFT JOIN nsf.ubigeo u ON u.id=a.ubigeo_id
	                                LEFT JOIN nsf.ubigeo pro ON pro.id=u.parent_id
	                                LEFT JOIN nsf.parameter_detail p ON p.id=a.type_param
	                                LEFT JOIN nsf.ubigeo dep ON dep.id=pro.parent_id
                                    WHERE ""client_id"" = @idClient";
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
