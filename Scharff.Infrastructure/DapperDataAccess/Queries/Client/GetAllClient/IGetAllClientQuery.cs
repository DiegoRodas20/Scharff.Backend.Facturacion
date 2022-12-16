using Scharff.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scharff.Infrastructure.DapperDataAccess.Queries.Client.GetAllClient
{
    public interface IGetAllClientQuery
    {
        Task<ClientModel> GetAllClient();
    }
}
