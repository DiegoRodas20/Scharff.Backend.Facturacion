using Scharff.Domain.Entities;

namespace Scharff.Infrastructure.Repositories.Contact.RegisterPhoneContact
{
    public interface IRegisterPhoneContactRepository
    {
        Task<int> RegisterPhoneContact(PhoneContactModel telefonoscontacto);

    }
}
