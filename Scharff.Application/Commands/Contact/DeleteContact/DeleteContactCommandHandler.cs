using MediatR;
using Scharff.Application.Commands.Contact.UpdateContact;
using Scharff.Domain.Entities;
using Scharff.Infrastructure.Repositories.Contact.DeleteContact;
using Scharff.Infrastructure.Repositories.Contact.UpdateContact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scharff.Application.Commands.Contact.DeleteContact
{
    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, ResponseModel>
    {
        private readonly IDeleteContactRepository _deleteContactRepository;
        public DeleteContactCommandHandler(IDeleteContactRepository deleteContactRepository)
        {
            _deleteContactRepository = deleteContactRepository;
        }
        public async Task<ResponseModel> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            ContactModel model = new()
            {
                Id = request.Id
            };

            var result = await _deleteContactRepository.DeleteContact(model.Id);
            return result;
        }
    }
}
