using MediatR;
using Scharff.Domain.Entities;
using Scharff.Infrastructure.Repositories.Contact.DeleteContact;
using Scharff.Infrastructure.Repositories.Contact.DeleteEmailContact;
using Scharff.Infrastructure.Repositories.Contact.DeletePhoneContact;
using System.ComponentModel.DataAnnotations;

namespace Scharff.Application.Commands.Contact.DeleteContact
{
    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, int>
    {
        private readonly IDeleteContactRepository _deleteContactRepository;
        private readonly IDeletePhoneContactRepository _deletePhoneContactRepository;
        private readonly IDeleteEmailContactRepository _deleteEmailContactRepository;

        public DeleteContactCommandHandler(IDeleteContactRepository deleteContactRepository, IDeletePhoneContactRepository deletePhoneContactRepository, IDeleteEmailContactRepository deleteEmailContactRepository)
        {
            _deleteContactRepository = deleteContactRepository;
            _deletePhoneContactRepository = deletePhoneContactRepository;
            _deleteEmailContactRepository = deleteEmailContactRepository;
        }

        public async Task<int> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            ContactModel model = new()
            {
                Id = request.Id
            };

            await _deletePhoneContactRepository.DeletePhoneContact(model.Id);
            await _deleteEmailContactRepository.DeleteEmailContact(model.Id);

            var resultContact = await _deleteContactRepository.DeleteContact(model.Id);

            if (resultContact <= 0) throw new ValidationException("No se encontro el id a eliminar");

            return model.Id;
        }
    }
}
