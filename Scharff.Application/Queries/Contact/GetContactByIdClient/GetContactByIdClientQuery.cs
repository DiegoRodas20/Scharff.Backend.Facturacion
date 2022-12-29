using MediatR;
using Scharff.Domain.Entities;

namespace Scharff.Application.Queries.Contact.GetContactoById
{
    public class GetContactByIdClientQuery : IRequest<List<ContactModel>>
    {
        public int IdClient { get; set; }

    }
}
