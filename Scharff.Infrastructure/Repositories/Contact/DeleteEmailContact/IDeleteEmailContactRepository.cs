namespace Scharff.Infrastructure.Repositories.Contact.DeleteEmailContact
{
    public interface IDeleteEmailContactRepository
    {
        Task<int> DeleteEmailContact(int IdContacto);

    }
}
