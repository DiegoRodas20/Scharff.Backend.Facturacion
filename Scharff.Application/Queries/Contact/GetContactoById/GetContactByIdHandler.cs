using MediatR;
using Scharff.Application.Queries.Client.GetClientById;
using Scharff.Domain.Entities;
using Scharff.Infrastructure.Queries.Client.GetClientById;
using Scharff.Infrastructure.Queries.Contact.GetContactById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scharff.Application.Queries.Contact.GetContactoById
{
    public class GetContactByIdHandler : IRequestHandler<GetContactByIdQuery, ContactModel>
    {
        private readonly IGetContactById _getContactByIdQuery;

        public GetContactByIdHandler(IGetContactById getContactByIdQuery)
        {
            _getContactByIdQuery = getContactByIdQuery;
        }
        public async Task<ContactModel> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _getContactByIdQuery.GetContactByID(request.IdClient);
            return result;
        }
    }
}
