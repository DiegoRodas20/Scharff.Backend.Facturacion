using MediatR;
using Scharff.Domain.Entities;

namespace Scharff.Application.Queries.Client.GetAddressByType
{
    public class GetAddressByTypeQuery : IRequest<AddressModel>
    {
        public int IdClient { get; set; }
        public int Type { get; set; }
    }
}
