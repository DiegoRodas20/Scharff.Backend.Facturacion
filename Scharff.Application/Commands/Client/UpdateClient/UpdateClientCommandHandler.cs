using MediatR;
using Scharff.Domain.Entities;
using Scharff.Infrastructure.Queries.Client.GetAllClients;
using Scharff.Infrastructure.Repositories.Client.UpdateClient;

namespace Scharff.Application.Commands.Client.UpdateClient
{
    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, int>
    {

        private readonly IUpdateClientRepository _updateClientRepository;
        private readonly IGetAllClients _getAllClients;
        public UpdateClientCommandHandler(
            IUpdateClientRepository updateClientRepository,
            IGetAllClients getAllClients
            )
        {
            _updateClientRepository = updateClientRepository;
            _getAllClients = getAllClients;
        }

        public async Task<int> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            ClientModel model = new()
            {
                //id = request.id,
                //tipoDocumentoIdentidad = request.tipoDocumentoIdentidad,
                //numeroDocumentoIdentidad = request.numeroDocumentoIdentidad,
                //razonSocial = request.razonSocial,
                //telefono = request.telefono,
                //nombreComercial = request.nombreComercial,
                //tipoMoneda_parametro = request.tipoMoneda_parametro,
                //grupoEmpresarial_parametro = request.grupoEmpresarial_parametro,
                //codigoSector_parametro = request.codigoSector_parametro,
                //holding_parametro = request.holding_parametro,
                //codigoSegmentacion_parametro = request.codigoSegmentacion_parametro,
                //comentario = request.comentario

                id = request.id,
                document_type_id = request.document_type_id,
                identity_document_number = request.identity_document_number,
                business_name = request.business_name,
                telephone = request.telephone,
                commercial_name = request.commercial_name,
                currency_type = request.currency_type,
                corporate_group_param = request.corporate_group_param,
                industry_code_param = request.industry_code_param,
                holding_param = request.holding_param,
                segmentation_code_param = request.segmentation_code_param,
                comment = request.comment
            };

            var result = await _updateClientRepository.UpdateClient(model);
            return result;
        }
    }
}

