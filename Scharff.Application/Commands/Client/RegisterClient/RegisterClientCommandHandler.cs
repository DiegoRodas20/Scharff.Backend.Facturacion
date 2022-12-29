using MediatR;
using Scharff.Domain.Entities;
using Scharff.Domain.Utils.Exceptions;
using Scharff.Infrastructure.Queries.Client.GetAllClients;
using Scharff.Infrastructure.Repositories.Client.RegisterClient;

namespace Scharff.Application.Commands.Client.RegisterClient
{
    public class RegisterClientCommandHandler : IRequestHandler<RegisterClientCommand, int>
    {
        private readonly IRegisterClientRepository _registerClientRepository;
        private readonly IGetAllClients _getAllClients;
        public RegisterClientCommandHandler(
            IRegisterClientRepository registerClientRepository,
            IGetAllClients getAllClients
            )
        {
            _registerClientRepository = registerClientRepository;
            _getAllClients = getAllClients;
        }

        public async Task<int> Handle(RegisterClientCommand request, CancellationToken cancellationToken)
        {
            ClientModel model = new()
            {
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

            //Validacion del documento de identidad
            var clientes = await _getAllClients.GetAllClient();
            if (clientes.Any(cliente => cliente.numeroDocumentoIdentidad == model.numeroDocumentoIdentidad)) throw new ValidationException("El numero de documento indicado ya esta registrado");
            //var client = await _getAllClientByNumDoc(model.numeroDocumentoIdentidad);
            //if(client != null) throw new ValidationException("El numero de documento indicado ya esta registrado");

            var result = await _registerClientRepository.RegisterClient(model);
            return result;
        }
    }
}
