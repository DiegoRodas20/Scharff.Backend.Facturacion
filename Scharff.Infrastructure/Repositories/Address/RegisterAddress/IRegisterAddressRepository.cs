using Scharff.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scharff.Infrastructure.Repositories.Direction.RegisterDirection
{
    public  interface IRegisterAddressRepository
    {
        Task<int> RegisterAddress(AddressModel direction);

    }
}
