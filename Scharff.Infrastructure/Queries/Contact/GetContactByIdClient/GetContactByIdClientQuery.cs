using Dapper;
using Npgsql;
using Scharff.Domain.Entities;
using System.Data;

namespace Scharff.Infrastructure.Queries.Contact.GetContactById
{
    public class GetContactByIdClientQuery : IGetContactByIdClientQuery
    {
        private readonly IDbConnection _connection;

        public GetContactByIdClientQuery(IDbConnection connection)
        {
            _connection = connection;
        }
        public async Task<List<ContactModel>> GetContactByIdClient(int idClient)
        {
            using (IDbConnection connection = new NpgsqlConnection(_connection.ConnectionString))
            {
                try
                {
                        string sql = @"  SELECT 
	                                         tc.Id,
	                                         tc.full_name,
	                                         tpdac.description as description_area_contact,
	                                         tpdtc.description as description_type_contact,
	                                         ttc.telephone as phone,
	                                         tec.email as email	   
                                         FROM nsf.contact  as tc
                                             LEFT JOIN nsf.parameter tpdac on tpdac.id = tc.area_param
                                             LEFT JOIN nsf.parameter tpdtc on tpdtc.id = tc.type_param
                                             INNER JOIN LATERAL  
                                             (
                                             	SELECT tmptc.contact_id,tmptc.id,tmptc.telephone
                                             	FROM nsf.phone_contact tmptc  
                                             	WHERE tmptc.contact_id = tc.Id 
                                             	AND tmptc.id = 
                                             	(
                                             		SELECT MIN(x.id) FROM
                                             		nsf.phone_contact x  
                                             		WHERE x.contact_id =  tc.Id 
                                             	)
                                             ) ttc on ttc.contact_id = tc.Id 
                                             INNER JOIN LATERAL  
                                             (
                                             	SELECT tmpte.contact_id,tmpte.id,tmpte.email
                                             	FROM
                                             	nsf.email_contact tmpte  
                                             	WHERE tmpte.contact_id =  tc.Id 
                                             	AND tmpte.id = 
                                             	(
                                             		SELECT MIN(x.id) FROM
                                             		nsf.email_contact x  
                                             		WHERE x.contact_id =  tc.Id 
                                             	)
                                             ) tec on tec.contact_id = tc.Id 
                                             WHERE client_id = @idClient and tc.status = 'true'";

                    var queryArgs = new { idClient };

                    IEnumerable<ContactModel> contact = await connection.QueryAsync<ContactModel>(sql, queryArgs);

                    return contact.ToList();
                }
                catch (NpgsqlException err)
                {
                    throw err;
                }
            }
        }
    }
}
