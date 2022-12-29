using Scharff.Domain.Entities;

namespace Scharff.Infrastructure.Repositories.Contact.UpdatePhoneContact
{
    public interface IUpdatePhoneContactRepository
    {
        Task<int> UpdatePhoneContact(PhoneContactModel telefonocontacto);
    }
}
