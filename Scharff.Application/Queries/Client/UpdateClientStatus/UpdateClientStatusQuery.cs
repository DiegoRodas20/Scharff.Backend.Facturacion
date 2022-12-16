using MediatR;
using Scharff.Domain.Entities;

namespace Scharff.Application.Queries.Client.UpdateClientStatus
{
    public class UpdateClientStatusQuery : IRequest<ClientModel>
    {
    }
}
