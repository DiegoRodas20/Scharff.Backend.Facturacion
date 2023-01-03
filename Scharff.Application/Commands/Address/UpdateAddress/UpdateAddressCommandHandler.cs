using MediatR;
using Scharff.Application.Commands.Contact.UpdateContact;
using Scharff.Domain.Entities;
using Scharff.Infrastructure.Repositories.Contact.UpdateContact;
using Scharff.Infrastructure.Repositories.Direction.UpdateDirection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scharff.Application.Commands.Direction.UpdateDirection
{
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, ResponseModel>
    {
        private readonly IUpdateDirectionRepository _updateDirectionRepository;
        public UpdateAddressCommandHandler(IUpdateDirectionRepository updateDirectionRepository)
        {
            _updateDirectionRepository = updateDirectionRepository;
        }
        public async Task<ResponseModel> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            AddressModel model = new()
            {
                id = request.id,
                status = request.status,
                type_param = request.type_param,
                client_id = request.client_id,
                ubigeo_id = request.ubigeo_id,
                unit_id=request.unit_id,
                address = request.address,
                postal_code = request.postal_code,
                modification_date = request.modification_date,
                modification_author = request.modification_author

            };

            var result = await _updateDirectionRepository.UpdateDirection(model);
            return result;
        }
    }
}
