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
										A.""id"",
										A.""grupoEmpresarial_parametro"",
										A.""codigoSector_parametro"",
										A.""tipoMoneda_parametro"",
										A.""tipoDocumentoIdentidad"",
										A.""numeroDocumentoIdentidad"",
										A.""telefono"",
										A.""razonSocial"",
										A.""nombreComercial"",
										A.""comentario"",
										A.""holding_parametro"",
										A.""codigoSegmentacion_parametro"",
										B.descripcion as ""descripcionGrupoEmpresarial"",
										C.descripcion as ""descripcionCodigoSector"",
										D.descripcion as ""descripcionTipoMoneda"",
										G.descripcion as ""descripcionTipoDocumentoIdentidad"",
										E.descripcion as ""descripcionHolding"",
										F.descripcion as ""descripcionCodigoSegmentacion""
									FROM 
										CLIENTE A INNER JOIN
										PARAMETRO_DETALLE B ON B.id = A.""grupoEmpresarial_parametro"" INNER JOIN
										PARAMETRO_DETALLE C ON C.id = A.""codigoSector_parametro"" INNER JOIN
										PARAMETRO_DETALLE D ON D.id = A.""tipoMoneda_parametro"" INNER JOIN
										PARAMETRO_DETALLE E ON E.id = A.""holding_parametro"" INNER JOIN
										PARAMETRO_DETALLE F ON F.id = A.""codigoSegmentacion_parametro"" INNER JOIN
										TIPO_DOCUMENTO_IDENTIDAD G ON G.id = A.""tipoDocumentoIdentidad""
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
