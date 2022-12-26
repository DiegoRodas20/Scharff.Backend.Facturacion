using Scharff.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scharff.Infrastructure.Queries.Contact.GetContactById
{
    public interface IGetContactByIdQuery
    {
        Task<List<ContactModel>> GetContactById(int idClient);

    }
}
