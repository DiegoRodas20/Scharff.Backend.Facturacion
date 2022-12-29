using Scharff.Domain.Entities;

namespace Scharff.Infrastructure.Repositories.Contact.UpdateContact
{
    public interface IUpdateContactRepository
    {
        Task<int> UpdateContact(ContactModel contacto);

    }
}
