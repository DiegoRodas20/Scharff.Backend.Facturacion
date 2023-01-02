using MediatR;
using Scharff.Domain.Entities;


namespace Scharff.Application.Queries.Address.GetAddressByIdClient
{
    public class GetAddressByIdClientQuery : IRequest<List<AddressModel>>
    {
        public int client_id { get; set; }
    }
}
