using Scharff.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scharff.Infrastructure.Queries.Address.GetAddressByIdClient
{
    public interface IGetAddressByIdClient
    {
        Task<List<DirectionModel>> GetDirectionByIdClient(int idClient);
    }
}
