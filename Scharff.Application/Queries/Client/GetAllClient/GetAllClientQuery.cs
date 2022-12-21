using MediatR;
using Scharff.Domain.Entities;

namespace Scharff.Application.Queries.Client.GetAllClient
{
    public class GetAllClientQuery : IRequest<ClientModel>
    {
    }
}
