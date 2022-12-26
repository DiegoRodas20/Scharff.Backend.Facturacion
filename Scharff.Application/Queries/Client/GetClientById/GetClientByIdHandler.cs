using MediatR;
using Scharff.Domain.Entities;
using Scharff.Infrastructure.Queries.Client.GetClientById;

namespace Scharff.Application.Queries.Client.GetClientById
{
    public class GetClientByIdHandler : IRequestHandler<GetClientByIdQuery, ClientModel>
    {
        private readonly IGetClientByIdQuery _getClientByIdQuery;

        public GetClientByIdHandler(IGetClientByIdQuery getClientByIdQuery)
        {
            _getClientByIdQuery = getClientByIdQuery;
        }

        public async Task<ClientModel> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _getClientByIdQuery.GetClientById(request.IdClient);

            if(result == null) throw new Exception("No se encontro el cliente con el id indicado.");

            return result;
        }
    }
}
