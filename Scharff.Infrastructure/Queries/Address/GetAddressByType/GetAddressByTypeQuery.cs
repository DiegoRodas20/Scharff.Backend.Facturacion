using Dapper;
using Npgsql;
using Scharff.Domain.Entities;
using System.Data;

namespace Scharff.Infrastructure.Queries.Client.GetAddressByType
{
    public class GetAddressByTypeQuery : IGetAddressByTypeQuery
    {
        private readonly IDbConnection _connection;

        public GetAddressByTypeQuery(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<AddressModel> GetAddressByType(int idClient, int type)
        {
            using (IDbConnection connection = new NpgsqlConnection(_connection.ConnectionString))
            {
                try
                {
                    string sql = @"	select ad.address, ad.postal_code, pd.description type_address
                                    from   nsf.address ad inner join
                                           nsf.parameter_detail pd  on ad.type_param = pd.id 
                                    where  ad.status = true 
                                      and  ad.client_id = @idClient
                                      and  ad.type_param = @type";

                    var queryArgs = new { idClient, type };

                    var address = await connection.QuerySingleAsync<AddressModel>(sql, queryArgs);
                    return address;
                }
                catch (NpgsqlException err)
                {
                    throw err;
                }
            }
        }
    }
}