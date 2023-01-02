using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scharff.Infrastructure.Repositories.Client.EnableClient
{
    public interface IEnableClientRepository
    {
        Task<int> EnableClient(int idClient);
    }
}
