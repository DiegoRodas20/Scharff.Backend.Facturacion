using MediatR;
using Scharff.Domain.Entities;
using Scharff.Infrastructure.DapperDataAccess.Queries.Client.GetAllClient;

namespace Scharff.Application.Queries.Client.GetAllClient
{
    public class GetAllClientHandler : IRequestHandler<GetAllClientQuery, ClientModel>
    {
        private readonly IGetAllClientQuery _getAllClientQuery;

        public GetAllClientHandler(IGetAllClientQuery getAllClientQuery)
        {
            _getAllClientQuery = getAllClientQuery;
        }

        public async Task<ClientModel> Handle(GetAllClientQuery request, CancellationToken cancellationToken)
        {
            var result = await _getAllClientQuery.GetAllClient();
            return result;
        }
    }
}
