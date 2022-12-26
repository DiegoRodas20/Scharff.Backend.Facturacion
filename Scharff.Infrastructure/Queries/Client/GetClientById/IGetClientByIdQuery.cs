using Scharff.Domain.Entities;

namespace Scharff.Infrastructure.Queries.Client.GetClientById
{
    public interface IGetClientByIdQuery
    {
        Task<ClientModel> GetClientById(int idClient);
    }
}
