using Scharff.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scharff.Infrastructure.Queries.Contact.GetContactById
{
    public interface IGetContactById
    {
        Task<ContactModel> GetContactByID(int idClient);

    }
}
