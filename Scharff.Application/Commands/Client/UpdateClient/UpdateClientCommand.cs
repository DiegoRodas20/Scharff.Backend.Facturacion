using MediatR;

namespace Scharff.Application.Commands.Client.UpdateClient
{
    public class UpdateClientCommand : IRequest<int>
    {
        public int id { get; set; }
        public int type_param { get; set; } //tipoCliente_parametro 
        public string? identity_document_number { get; set; } //numeroDocumentoIdentidad
        public int segmentation_code_param { get; set; } //codigoSegmentacion_parametro
        public int document_type_id { get; set; } //tipoDocumentoIdentidad
        public int geographic_location_id { get; set; } //idUbicacionGeografica
        public string? business_name { get; set; } //razonSocial
        public int industry_code_param { get; set; } //codigoSector_parametro
        public string? telephone { get; set; } //telefono
        public string? fedex_account { get; set; } //cuentaFedex
        public bool fedex_authorized_account { get; set; } //cuentaAutorizadaFedex
        public DateTime fedex_authorization_date { get; set; } //fechaAutorizacionFedex
        public string? commercial_name { get; set; } //nombreComercial
        public string? comment { get; set; } //comentario
        public int currency_type { get; set; } //tipoMoneda_parametro
        public int corporate_group_param { get; set; } //grupoEmpresarial_parametro
        public int holding_param { get; set; } //holding_parametro
        public string? sap_id { get; set; } //codigoSap
        public bool status { get; set; } //estadoCliente
        public int sap_state_param { get; set; } //estadoSap_parametro
        public int validate_status_param { get; set; } //estadoSR_parametro
        public DateTime creation_date { get; set; } //fechaCreacion
        public int creation_author { get; set; } //autorCreacion
        public DateTime modification_date { get; set; } //fechaModificacion
        public int modification_author { get; set; } //autorModificacion
    }
}
