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
                id = request.id,
                tipoDocumentoIdentidad = request.tipoDocumentoIdentidad,
                numeroDocumentoIdentidad = request.numeroDocumentoIdentidad,
                razonSocial = request.razonSocial,
                telefono = request.telefono,
                nombreComercial = request.nombreComercial,
                tipoMoneda_parametro = request.tipoMoneda_parametro,
                grupoEmpresarial_parametro = request.grupoEmpresarial_parametro,
                codigoSector_parametro = request.codigoSector_parametro,
                holding_parametro = request.holding_parametro,
                codigoSegmentacion_parametro = request.codigoSegmentacion_parametro,
                comentario = request.comentario
            };

            var result = await _updateClientRepository.UpdateClient(model);
            return result;
        }
    }
}

