using MediatR;
using Scharff.Domain.Entities;
using Scharff.Infrastructure.Queries.Client.GetAddressByType;

namespace Scharff.Application.Queries.Client.GetAddressByType
{
    public class GetAddressByTypeHandler : IRequestHandler<GetAddressByTypeQuery, AddressModel>
    {
        private readonly IGetAddressByTypeQuery _getAddressByTypeQuery;

        public GetAddressByTypeHandler(IGetAddressByTypeQuery getAddressByTypeQuery)
        {
            _getAddressByTypeQuery = getAddressByTypeQuery;
        }

        public async Task<AddressModel> Handle(GetAddressByTypeQuery request, CancellationToken cancellationToken)
        {
            var result = await _getAddressByTypeQuery.GetAddressByType(request.IdClient, request.Type);

            if(result == null) throw new Exception("No se encontró el cliente con el tipo de dirección solicitado.");

            return result;
        }
    }
}
