using Scharff.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scharff.Infrastructure.Repositories.Client.UpdateClient
{
    public interface IUpdateClientRepository
    {
        Task<int> UpdateClient(ClientModel client);

    }
}
