﻿using MediatR;
using Scharff.Domain.Entities;
using Scharff.Infrastructure.Repositories.Client.RegisterClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scharff.Application.Commands.Client.RegisterClient
{
    public class RegisterClientCommandHandler : IRequestHandler<RegisterClientCommand, ResponseModel>
    {
        private readonly IRegisterClientRepository _registerClientRepository;

        public RegisterClientCommandHandler(IRegisterClientRepository registerClientRepository)
        {
            _registerClientRepository = registerClientRepository;
        }

        public async Task<ResponseModel> Handle(RegisterClientCommand request, CancellationToken cancellationToken)
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

            var result = await _registerClientRepository.RegisterClient(model);
            return result;
        }
    }
}
