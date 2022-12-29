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
	                                tc.""nombreCompleto"" as nombreCompleto,
	                                tpdac.""id"" as areaContacto_parametro,
	                                tpdtc.""id"" as tipoContacto_parametro   
                                    FROM public.contacto  as tc
                                    INNER JOIN public.parametro_detalle tpdac on tpdac.id = tc.""areaContacto_parametro""
                                    INNER JOIN public.parametro_detalle tpdtc on tpdtc.id = tc.""tipoContacto_parametro""
                                    WHERE tc.Id = @Id and tc.estado = 'true'
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
                                    	  tc.telefono as telefono
                                    FROM public.telefono_contacto tc
                                    WHERE tc.""idContacto"" = @Id 
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
                                   FROM public.email_contacto ec
                                   WHERE ec.""idContacto"" = @Id 
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
