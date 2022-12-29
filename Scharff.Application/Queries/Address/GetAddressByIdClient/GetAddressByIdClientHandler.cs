using MediatR;
using Scharff.Domain.Entities;
using Scharff.Infrastructure.Queries.Address.GetAddressByIdClient;


namespace Scharff.Application.Queries.Address.GetAddressByIdClient
{
    internal class GetAddressByIdClientHandler : IRequestHandler<GetAddressByIdClientQuery, List<DirectionModel>>
    {
        private readonly IGetAddressByIdClient _getDirectionByIdClientQuery;

        public GetAddressByIdClientHandler(IGetAddressByIdClient getDirectionByIdQuery)
        {
            _getDirectionByIdClientQuery = getDirectionByIdQuery;
        }
        public async Task<List<DirectionModel>> Handle(GetAddressByIdClientQuery request, CancellationToken cancellationToken)
        {
            var result = await _getDirectionByIdClientQuery.GetDirectionByIdClient(request.IdCliente);
            return result;
        }
    }
}
