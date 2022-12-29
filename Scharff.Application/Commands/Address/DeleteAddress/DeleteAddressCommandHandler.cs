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
    public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand, ResponseModel>
    {
        private readonly IDeleteAddressRepository _deleteAddressRepository;
        public DeleteAddressCommandHandler(IDeleteAddressRepository deleteAddressRepository)
        {
            _deleteAddressRepository = deleteAddressRepository;
        }
        public async Task<ResponseModel> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            AddressModel model = new()
            {
                Id = request.Id
            };

            var result = await _deleteAddressRepository.DeleteAddress(model.Id);
            return result;
        }
    }
}
