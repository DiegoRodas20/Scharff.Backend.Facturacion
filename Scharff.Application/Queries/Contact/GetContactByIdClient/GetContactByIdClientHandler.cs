using MediatR;
using Scharff.Domain.Entities;
using Scharff.Infrastructure.Queries.Contact.GetContactById;

namespace Scharff.Application.Queries.Contact.GetContactoById
{
    public class GetContactByIdClientHandler : IRequestHandler<GetContactByIdClientQuery, List<ContactModel>>
    {
        private readonly IGetContactByIdClientQuery _getContactByIdClientQuery;

        public GetContactByIdClientHandler(IGetContactByIdClientQuery getContactByIdClientQuery)
        {
            _getContactByIdClientQuery = getContactByIdClientQuery;
        }
        public async Task<List<ContactModel>> Handle(GetContactByIdClientQuery request, CancellationToken cancellationToken)
        {
            var result = await _getContactByIdClientQuery.GetContactByIdClient(request.IdClient);
            return result;
        }
    }
}
