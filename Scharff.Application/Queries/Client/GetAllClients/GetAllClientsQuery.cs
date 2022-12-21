using MediatR;
using Scharff.Domain.Entities;

namespace Scharff.Application.Queries.Client.GetAllClients
{
    public class GetAllClientsQuery : IRequest<List<ClientModel>>
    {
    }
}
