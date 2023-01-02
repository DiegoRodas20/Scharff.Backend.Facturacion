using MediatR;
using Scharff.Domain.Entities;


namespace Scharff.Application.Queries.Direction.GetDirectionById
{
    public class GetAddressByIdQuery : IRequest<List<AddressModel>>
    {
        public int Id { get; set; }

    }
}
