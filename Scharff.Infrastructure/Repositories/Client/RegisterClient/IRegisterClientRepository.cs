using Scharff.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scharff.Infrastructure.Repositories.Client.RegisterClient
{
    public interface IRegisterClientRepository
    {
        Task<int> RegisterClient(ClientModel cliente);
    }
}
