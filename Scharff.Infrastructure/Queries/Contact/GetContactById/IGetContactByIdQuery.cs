using Scharff.Domain.Entities;
using static Scharff.Domain.Entities.ContactModel;

namespace Scharff.Infrastructure.Queries.Contact.GetContactById
{
    public interface IGetContactByIdQuery
    {
        Task<ContactModel> GetContactById(int id);
        Task<List<GetPhoneContactModelDTO>> GetPhonesById(int Id);
        Task<List<GetEmailContactModelDTO>> GetEmailsById(int Id);
    }
}
