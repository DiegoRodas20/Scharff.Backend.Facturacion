using MediatR;
using Scharff.Domain.Entities;

namespace Scharff.Application.Queries.Client.GetClientById
{
    public class GetClientByIdQuery : IRequest<ClientModel>
    {
        public int IdClient { get; set; }
    }
}
