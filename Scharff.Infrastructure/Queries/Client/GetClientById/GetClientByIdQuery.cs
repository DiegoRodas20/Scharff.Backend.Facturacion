using Dapper;
using Npgsql;
using Scharff.Domain.Entities;
using System.Data;

namespace Scharff.Infrastructure.Queries.Client.GetClientById
{
    public class GetClientByIdQuery : IGetClientByIdQuery
    {
        private readonly IDbConnection _connection;

        public GetClientByIdQuery(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<ClientModel> GetClientById(int idClient)
        {
            using (IDbConnection connection = new NpgsqlConnection(_connection.ConnectionString))
            {
                try
                {
                    string sql = @"	 SELECT
										A.id,
										A.corporate_group_param,
										A.industry_code_param,
										A.currency_type,
										A.document_type_id,
										A.identity_document_number,
										A.telephone,
										A.business_name,
										A.commercial_name,
										A.comment,
										A.holding_param,
										A.segmentation_code_param,									
										A.status,
										B.description as business_group_description,
										C.description as sector_code_description,
										D.description as coin_type_description,
										G.description as identity_document_type_description,
										E.description as holding_description,
										F.description as segmentation_code_description
									FROM 
										nsf.client A INNER JOIN
										nsf.parameter_detail B ON B.id = A.corporate_group_param INNER JOIN
										nsf.parameter_detail C ON C.id = A.industry_code_param INNER JOIN
										nsf.parameter_detail D ON D.id = A.currency_type INNER JOIN
										nsf.parameter_detail E ON E.id = A.holding_param INNER JOIN
										nsf.parameter_detail F ON F.id = A.segmentation_code_param INNER JOIN
										nsf.parameter_detail G ON G.id = A.document_type_id
									WHERE
										A.id = @idClient";

                    var queryArgs = new { idClient };

                    var client = await connection.QuerySingleAsync<ClientModel>(sql, queryArgs);
                    return client;
                }
                catch (NpgsqlException err)
                {
                    throw err;
                }
            }
        }
    }
}
