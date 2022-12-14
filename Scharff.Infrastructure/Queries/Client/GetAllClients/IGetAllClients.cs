using Scharff.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scharff.Infrastructure.Queries.Client.GetAllClients
{
    public interface IGetAllClients
    {
        Task<List<ClientModel>> GetAllClient();
    }
}
