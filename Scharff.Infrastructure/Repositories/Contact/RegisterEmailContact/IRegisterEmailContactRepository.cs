using Scharff.Domain.Entities;

namespace Scharff.Infrastructure.Repositories.Contact.RegisterEmailContact
{
    public interface  IRegisterEmailContactRepository
    {
        Task<int> RegisterEmailContact(EmailContactModel emailscontacto);

    }
}
