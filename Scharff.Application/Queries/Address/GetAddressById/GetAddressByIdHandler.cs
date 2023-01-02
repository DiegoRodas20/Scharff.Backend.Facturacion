using MediatR;
using Scharff.Application.Queries.Client.GetClientById;
using Scharff.Domain.Entities;
using Scharff.Infrastructure.Queries.Client.GetClientById;
using Scharff.Infrastructure.Queries.Direction.GetDirectionById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scharff.Application.Queries.Direction.GetDirectionById
{
    public class GetAddressByIdHandler : IRequestHandler<GetAddressByIdQuery, List<AddressModel>>
    {
        private readonly IGetAddressById _getDirectionByIdQuery;

        public GetAddressByIdHandler(IGetAddressById getDirectionByIdQuery)
        {
            _getDirectionByIdQuery = getDirectionByIdQuery;
        }
        public async Task<List<AddressModel>> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _getDirectionByIdQuery.GetDirectionByID(request.id);
            return result;
        }
    }
}
