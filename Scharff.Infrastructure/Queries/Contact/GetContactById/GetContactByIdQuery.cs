using Dapper;
using Npgsql;
using Scharff.Domain.Entities;
using System.Data;
using static Scharff.Domain.Entities.ContactModel;

namespace Scharff.Infrastructure.Queries.Contact.GetContactById
{
    public class GetContactByIdQuery : IGetContactByIdQuery
    {
        private readonly IDbConnection _connection;

        public GetContactByIdQuery(IDbConnection connection)
        {
            _connection = connection;
        }
        public async Task<ContactModel> GetContactById(int Id)
        {
            using (IDbConnection connection = new NpgsqlConnection(_connection.ConnectionString))
            {
                try
                {
                    string sql = @"SELECT 
	                                tc.Id as Id,
	                                tc.full_name as full_name,
	                                tpdac.id as type_param,
	                                tpdtc.id as area_param   
                                    FROM nsf.contact  as tc
                                    LEFT JOIN nsf.parameter tpdac on tpdac.id = tc.area_param
                                    LEFT JOIN nsf.parameter tpdtc on tpdtc.id = tc.type_param
                                    WHERE tc.Id = @Id and tc.status = 'true'
                                    ";

                    var queryArgs = new { Id };

                    ContactModel contact = await connection.QuerySingleOrDefaultAsync<ContactModel>(sql, queryArgs);

                    return contact;

                }
                catch (NpgsqlException err)
                {
                    throw err;
                }
            }
        }
        public async Task<List<GetPhoneContactModelDTO>> GetPhonesById(int Id)
        {
            using (IDbConnection connection = new NpgsqlConnection(_connection.ConnectionString))
            {
                try
                {
                    string sql = @"SELECT tc.Id as Id,
                                    	  tc.telephone as telefono
                                    FROM nsf.phone_contact tc
                                    WHERE tc.""contact_id"" = @Id 
                                    ";

                    var queryArgs = new { Id };

                    var results = await connection.QueryAsync<GetPhoneContactModelDTO>(sql, queryArgs);
                    List<GetPhoneContactModelDTO> contactphones = results.ToList();

                    return contactphones;

                }
                catch (NpgsqlException err)
                {
                    throw err;
                }
            }
        }
        public async Task<List<GetEmailContactModelDTO>> GetEmailsById(int Id)
        {
            using (IDbConnection connection = new NpgsqlConnection(_connection.ConnectionString))
            {
                try
                {
                    string sql = @"SELECT ec.Id as Id,
                                   	      ec.email as email
                                   FROM nsf.email_contact ec
                                   WHERE ec.""contact_id"" = @Id 
                                    ";

                    var queryArgs = new { Id };
                    var results = await connection.QueryAsync<GetEmailContactModelDTO>(sql, queryArgs);

                    List<GetEmailContactModelDTO> contactemails = results.ToList();

                    return contactemails.ToList();

                }
                catch (NpgsqlException err)
                {
                    throw err;
                }
            }
        }
    }

}
