using MediatR;
using Scharff.Domain.Entities;
using Scharff.Infrastructure.Queries.Client.GetAllClients;
using Scharff.Infrastructure.Repositories.Client.RegisterClient;
using Scharff.Domain.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                tipoDocumentoIdentidad = request.TypeDocumentIdentity,
                numeroDocumentoIdentidad = request.NumberDocumentIdentity,
                razonSocial = request.CompanyName,
                telefono = request.Phone,
                nombreComercial = request.TradeName,
                tipoMoneda_parametro = request.TypeCurrency,
                grupoEmpresarial_parametro = request.BusinessGroup,
                codigoSector_parametro = request.CodeEconomicSector,
                holding_parametro = request.Holding,
                codigoSegmentacion_parametro = request.CodeSegmentation
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
