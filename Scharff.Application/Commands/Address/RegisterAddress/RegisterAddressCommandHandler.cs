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
                client_id = request.client_id,
                type_param = request.type_param,
                unit_id = request.unit_id,
                address = request.address,
                status = request.status,
                creation_date = request.creation_date,
                creation_author = request.creation_author
            };

            var result = await _registerAddressRepository.RegisterAddress(model);
            return result;
        }
    }
}
