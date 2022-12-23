using MediatR;
using Scharff.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scharff.Application.Queries.Contact.GetContactoById
{
    public class GetContactByIdQuery : IRequest<ContactModel>
    {
        public int IdClient { get; set; }

    }
}
