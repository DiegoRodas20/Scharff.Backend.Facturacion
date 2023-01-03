using MediatR;
using Scharff.Domain.Entities;
using Scharff.Infrastructure.Queries.Contact.GetContactById;
using System.ComponentModel.DataAnnotations;

namespace Scharff.Application.Queries.Contact.GetContactById
{
    public class GetContactByIdHandler : IRequestHandler<GetContactByIdQuery, ContactModel>
    {
        private readonly IGetContactByIdQuery _getContactByIdQuery;

        public GetContactByIdHandler(IGetContactByIdQuery getContactByIdQuery)
        {
            _getContactByIdQuery = getContactByIdQuery;
        }
        public async Task<ContactModel> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            var resultContact = await _getContactByIdQuery.GetContactById(request.Id);

            if (resultContact == null) throw new ValidationException("No se encontro el contacto");

            if (resultContact != null)
            {
                var resultPhonesContact = await _getContactByIdQuery.GetPhonesById(request.Id);
                var resultEmailsContact = await _getContactByIdQuery.GetEmailsById(request.Id);

                if (resultPhonesContact.Count() > 0) resultContact.phones_contact = resultPhonesContact;
                if (resultEmailsContact.Count() > 0) resultContact.emails_contact = resultEmailsContact;
            }

            return resultContact;
        }
    }
}
