using Scharff.Domain.Entities;

namespace Scharff.Infrastructure.Queries.Contact.GetContactById
{
    public interface IGetContactByIdClientQuery
    {
        Task<List<ContactModel>> GetContactByIdClient(int idClient);

    }
}
