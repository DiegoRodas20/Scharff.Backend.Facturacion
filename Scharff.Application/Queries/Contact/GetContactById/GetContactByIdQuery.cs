using MediatR;
using Scharff.Domain.Entities;

namespace Scharff.Application.Queries.Contact.GetContactById
{
    public class GetContactByIdQuery : IRequest<ContactModel>
    {
        public int Id { get; set; }

    }
}
