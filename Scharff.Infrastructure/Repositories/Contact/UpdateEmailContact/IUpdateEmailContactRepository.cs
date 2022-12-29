using Scharff.Domain.Entities;

namespace Scharff.Infrastructure.Repositories.Contact.UpdateEmailContact
{
    public interface IUpdateEmailContactRepository
    {
        Task<int> UpdateEmailContact(EmailContactModel emailcontacto);
    }
}
