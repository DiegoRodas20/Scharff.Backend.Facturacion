using MediatR;
using Scharff.Domain.Entities;
using Scharff.Infrastructure.DapperDataAccess.Queries.Client.UpdateClientStatus;

namespace Scharff.Application.Queries.Client.UpdateClientStatus
{
    public class UpdateClientStatusHandler : IRequestHandler<UpdateClientStatusQuery, ClientModel>
    {
        private readonly IUpdateClientStatusQuery _updateClientStatusQuery;

        public UpdateClientStatusHandler(IUpdateClientStatusQuery updateClientStatusQuery)
        {
            _updateClientStatusQuery = updateClientStatusQuery;
        }

        public async Task<ClientModel> Handle(UpdateClientStatusQuery request, CancellationToken cancellationToken)
        {
            var result = await _updateClientStatusQuery.UpdateClientStatus(1);
            return result;
        }
    }
}
