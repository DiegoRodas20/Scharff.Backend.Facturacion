using MediatR;
using Scharff.Application.Commands.Contact.DeleteContact;
using Scharff.Domain.Entities;
using Scharff.Infrastructure.Repositories.Contact.DeleteContact;
using Scharff.Infrastructure.Repositories.Direction.DeleteDirection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scharff.Application.Commands.Direction.DeleteDirection
{
    public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand, int>
    {
        private readonly IDeleteAddressRepository _deleteAddressRepository;
        public DeleteAddressCommandHandler(IDeleteAddressRepository deleteAddressRepository)
        {
            _deleteAddressRepository = deleteAddressRepository;
        }
        public async Task<int> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            AddressModel model = new()
            {
                id = request.Id
            };

            var result = await _deleteAddressRepository.DeleteAddress(model.id);
            return result;
        }
    }
}
