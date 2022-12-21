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
                TypeDocumentIdentity = request.TypeDocumentIdentity,
                NumberDocumentIdentity = request.NumberDocumentIdentity,
                CompanyName = request.CompanyName,
                Phone = request.Phone,
                TradeName = request.TradeName,
                TypeCurrency = request.TypeCurrency,
                BusinessGroup = request.BusinessGroup,
                CodeEconomicSector = request.CodeEconomicSector,
                Holding = request.Holding,
                CodeSegmentation = request.CodeSegmentation
            };

            var result = await _registerClientRepository.RegisterClient(model);
            return result;
        }
    }
}
