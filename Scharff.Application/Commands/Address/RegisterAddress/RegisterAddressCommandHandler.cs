using MediatR;
using Scharff.Application.Commands.Contact.RegisterContact;
using Scharff.Domain.Entities;
using Scharff.Infrastructure.Repositories.Contact.RegisterContact;
using Scharff.Infrastructure.Repositories.Direction.RegisterDirection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scharff.Application.Commands.Direction.RegisterDirection
{
    public class RegisterAddressCommandHandler : IRequestHandler<RegisterAddressCommand, int>
    {
        private readonly IRegisterAddressRepository _registerAddressRepository;
        public RegisterAddressCommandHandler(IRegisterAddressRepository registerAddressRepository)
        {
            _registerAddressRepository = registerAddressRepository;
        }

        public async Task<int> Handle(RegisterAddressCommand request, CancellationToken cancellationToken)
        {

            AddressModel model = new()
            {
                type_param = request.type_param,
                client_id = request.client_id,
                address = request.address,
            };

            var result = await _registerAddressRepository.RegisterAddress(model);
            return result;
        }
    }
}
