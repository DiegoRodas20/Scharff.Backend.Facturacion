namespace Scharff.Infrastructure.Repositories.Contact.DeletePhoneContact
{
    public interface IDeletePhoneContactRepository
    {
        Task<int> DeletePhoneContact(int IdContacto);

    }
}
