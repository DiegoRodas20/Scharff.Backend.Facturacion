using Scharff.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scharff.Infrastructure.Queries.Direction.GetDirectionById
{
    public interface IGetDirectionById
    {
        Task<List<DirectionModel>> GetDirectionByID(int id);
    }
}
