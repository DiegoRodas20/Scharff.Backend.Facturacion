using Scharff.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scharff.Infrastructure.Repositories.Direction.DeleteDirection
{
    public  interface IDeleteAddressRepository
    {
        Task<int> DeleteAddress(int Id);

    }
}
