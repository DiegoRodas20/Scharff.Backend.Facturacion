using Scharff.Domain.Entities;

namespace Scharff.Infrastructure.Queries.Client.GetAddressByType
{
    public interface IGetAddressByTypeQuery
    {
        Task<AddressModel> GetAddressByType(int idClient, int type);
    }
}
