using Scharff.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scharff.Infrastructure.DapperDataAccess.Queries.Client.UpdateClientStatus
{
    public interface IUpdateClientStatusQuery
    {
        Task<ClientModel> UpdateClientStatus(int idClient);
    }
}
