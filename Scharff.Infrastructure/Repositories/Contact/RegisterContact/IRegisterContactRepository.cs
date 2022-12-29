using Scharff.Domain.Entities;

namespace Scharff.Infrastructure.Repositories.Contact.RegisterContact
{
    public interface IRegisterContactRepository
    {
        Task<int> RegisterContact(ContactModel contacto);

    }
}
