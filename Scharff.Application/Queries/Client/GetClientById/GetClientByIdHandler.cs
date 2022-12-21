using MediatR;
using Scharff.Domain.Entities;
using Scharff.Infrastructure.Queries.Client.GetClientById;

namespace Scharff.Application.Queries.Client.GetClientById
{
    public class GetClientByIdHandler : IRequestHandler<GetClientByIdQuery, ClientModel>
    {
        private readonly IGetClientById _getClientByIdQuery;

        public GetClientByIdHandler(IGetClientById getClientByIdQuery)
        {
            _getClientByIdQuery = getClientByIdQuery;
        }

        public async Task<ClientModel> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _getClientByIdQuery.GetClientByID(request.IdClient);
            return result;
        }
    }
}
