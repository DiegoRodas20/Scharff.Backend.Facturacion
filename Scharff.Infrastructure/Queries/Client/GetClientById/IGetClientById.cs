using Scharff.Domain.Entities;

namespace Scharff.Infrastructure.Queries.Client.GetClientById
{
    public interface IGetClientById
    {
        Task<ClientModel> GetClientByID(int idClient);
    }
}
