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
    public class GetContactByIdHandler : IRequestHandler<GetContactByIdQuery, List<ContactModel>>
    {
        private readonly IGetContactByIdQuery _getContactByIdQuery;

        public GetContactByIdHandler(IGetContactByIdQuery getContactByIdQuery)
        {
            _getContactByIdQuery = getContactByIdQuery;
        }
        public async Task<List<ContactModel>> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _getContactByIdQuery.GetContactById(request.IdClient);
            return result;
        }
    }
}
