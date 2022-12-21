using MediatR;
using Scharff.Domain.Entities;
using Scharff.Infrastructure.Queries.Client.GetAllClients;

namespace Scharff.Application.Queries.Client.GetAllClients
{
    public class GetAllClientsHandler : IRequestHandler<GetAllClientsQuery, List<ClientModel>>
    {
        private readonly IGetAllClients _getAllClients;
        public GetAllClientsHandler(IGetAllClients getAllClients)
        {
            _getAllClients = getAllClients;
        }

        public async Task<List<ClientModel>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
        {
            var result = await _getAllClients.GetAllClient();
            return result;
        }
    }
}
