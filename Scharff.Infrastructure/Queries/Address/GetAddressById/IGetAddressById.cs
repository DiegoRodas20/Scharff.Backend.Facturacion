using Scharff.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scharff.Infrastructure.Queries.Direction.GetDirectionById
{
    public interface IGetAddressById
    {
        Task<List<AddressModel>> GetDirectionByID(int id);
    }
}
