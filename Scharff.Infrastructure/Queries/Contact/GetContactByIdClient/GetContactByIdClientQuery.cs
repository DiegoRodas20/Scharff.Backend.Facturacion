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
                    string sql = @"SELECT 
	                                tc.Id as Id,
	                                tc.""nombreCompleto"" as nombreCompleto,
	                                tpdac.""descripcion"" as descripcionAreaContacto,
	                                tpdtc.""descripcion"" as descripcionTipoContacto,
	                                ttc.telefono as telefono,
	                                tec.email as email	   
                                FROM public.contacto  as tc
                                    INNER JOIN public.parametro_detalle tpdac on tpdac.id = tc.""areaContacto_parametro""
                                    INNER JOIN public.parametro_detalle tpdtc on tpdtc.id = tc.""tipoContacto_parametro""
                                    INNER JOIN LATERAL  
                                    (
                                    	SELECT tmptc.""idContacto"",tmptc.""id"",tmptc.telefono
                                    	FROM
                                    	public.telefono_contacto tmptc  
                                    	WHERE tmptc.""idContacto"" =  tc.Id 
                                    	AND tmptc.""id"" = 
                                    	(
                                    		SELECT MIN(x.""id"") FROM
                                    		public.telefono_contacto x  
                                    		WHERE x.""idContacto"" =  tc.Id 
                                    	)
                                    ) ttc on ttc.""idContacto"" = tc.Id 
                                    INNER JOIN LATERAL  
                                    (
                                    	SELECT tmpte.""idContacto"",tmpte.""id"",tmpte.email
                                    	FROM
                                    	public.email_contacto tmpte  
                                    	WHERE tmpte.""idContacto"" =  tc.Id 
                                    	AND tmpte.""id"" = 
                                    	(
                                    		SELECT MIN(x.""id"") FROM
                                    		public.email_contacto x  
                                    		WHERE x.""idContacto"" =  tc.Id 
                                    	)
                                    ) tec on tec.""idContacto"" = tc.Id 
                                    WHERE ""idCliente"" = @idClient and tc.estado = 'true'
                                     ";

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
