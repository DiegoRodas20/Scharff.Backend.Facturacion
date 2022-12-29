using MediatR;

namespace Scharff.Application.Commands.Contact.DeleteContact
{
    public class DeleteContactCommand : IRequest<int>
    {
        public int Id { get; set; }

    }
}
