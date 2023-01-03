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
										nsf.parameter B ON B.detail_id = A.corporate_group_param and B.group_id = 1 INNER JOIN
										nsf.parameter C ON C.detail_id = A.industry_code_param and C.group_id = 2 INNER JOIN
										nsf.parameter D ON D.detail_id = A.currency_type and D.group_id = 3 INNER JOIN
										nsf.parameter E ON E.detail_id = A.holding_param and E.group_id = 4 INNER JOIN
										nsf.parameter F ON F.detail_id = A.segmentation_code_param and F.group_id = 5 INNER JOIN
										nsf.parameter G ON G.detail_id = A.document_type_id and G.group_id = 6
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
