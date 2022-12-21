using MediatR;
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
                TypeDocumentIdenty = request.TypeDocumentIdenty,
                IdentificationNumber = request.IdentificationNumber,
                BusinessName = request.BusinessName,
                Phone = request.Phone,
                TradeName = request.TradeName,
                TypeCurrency = request.TypeCurrency,
                BusinessGroup = request.BusinessGroup,
                EconomicSector = request.EconomicSector,
                Holding = request.Holding,
                Segmentation = request.Segmentation
            };

            var result = await _registerClientRepository.RegisterClient(model);
            return result;
        }
    }
}
