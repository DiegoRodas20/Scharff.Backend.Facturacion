using Scharff.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scharff.Infrastructure.Repositories.Contact.RegisterContact
{
    public interface IRegisterContactRepository
    {
        Task<ResponseModel> RegisterContact(ContactModel contacto);

    }
}
