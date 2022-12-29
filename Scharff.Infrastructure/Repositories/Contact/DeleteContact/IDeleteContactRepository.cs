namespace Scharff.Infrastructure.Repositories.Contact.DeleteContact
{
    public interface IDeleteContactRepository
    {
        Task<int> DeleteContact(int Id);

    }
}
