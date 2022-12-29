using MediatR;
using Scharff.Domain.Entities;


namespace Scharff.Application.Queries.Address.GetAddressByIdClient
{
    public class GetAddressByIdClientQuery : IRequest<List<DirectionModel>>
    {
        public int IdCliente { get; set; }
    }
}
