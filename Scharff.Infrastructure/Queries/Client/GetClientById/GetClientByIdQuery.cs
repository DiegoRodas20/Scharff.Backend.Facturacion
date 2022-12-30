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
										A.corporate_group_param, --grupoEmpresarial_parametro,
										A.industry_code_param, --codigoSector_parametro,
										A.currency_type, --tipoMoneda_parametro,
										A.document_type_id, --tipoDocumentoIdentidad,
										A.identity_document_number, --numeroDocumentoIdentidad,
										A.telephone, --telefono,
										A.business_name, --razonSocial,
										A.commercial_name, --nombreComercial,
										A.comment, --comentario,
										A.holding_param, --holding_parametro,
										A.segmentation_code_param, --codigoSegmentacion_parametro,										
										A.status, --estadoCliente,
										B.description as business_group_description, --B.descripcion as descripcionGrupoEmpresarial,
										C.description as sector_code_description, --C.descripcion as descripcionCodigoSector,
										D.description as coin_type_description, --D.descripcion as descripcionTipoMoneda,
										G.description as identity_document_type_description, --G.descripcion as descripcionTipoDocumentoIdentidad,
										E.description as holding_description, --E.descripcion as descripcionHolding,
										F.description as segmentation_code_description --F.descripcion as descripcionCodigoSegmentacion
									FROM 
										nsf.client A INNER JOIN
										nsf.parameter B ON B.detail_id = A.corporate_group_param and B.group_id = (ingresar codigo de grupo) INNER JOIN --A.grupoEmpresarial_parametro 
										nsf.parameter C ON C.detail_id = A.industry_code_param and C.group_id = (ingresar codigo de grupo) INNER JOIN --codigoSector_parametro 
										nsf.parameter D ON D.detail_id = A.currency_type and D.group_id = (ingresar codigo de grupo) INNER JOIN --tipoMoneda_parametro 
										nsf.parameter E ON E.detail_id = A.holding_param and E.group_id = (ingresar codigo de grupo) INNER JOIN --holding_parametro
										nsf.parameter F ON F.detail_id = A.segmentation_code_param and F.group_id = (ingresar codigo de grupo) INNER JOIN --codigoSegmentacion_parametro 
										--TIPO_DOCUMENTO_IDENTIDAD G ON G.id = A.tipoDocumentoIdentidad
										nsf.parameter G ON G.detail_id = A.document_type_id and G.group_id = (ingresar codigo de grupo) --segmentation_code_param
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
