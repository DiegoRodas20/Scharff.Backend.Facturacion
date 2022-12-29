using MediatR;
using Scharff.Domain.Entities;
using Scharff.Infrastructure.Repositories.Contact.UpdateContact;
using Scharff.Infrastructure.Repositories.Contact.UpdateEmailContact;
using Scharff.Infrastructure.Repositories.Contact.UpdatePhoneContact;
using System.ComponentModel.DataAnnotations;

namespace Scharff.Application.Commands.Contact.UpdateContact
{
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, int>
    {
        private readonly IUpdateContactRepository _updateContactRepository;
        private readonly IUpdatePhoneContactRepository _updatePhoneContactRepository;
        private readonly IUpdateEmailContactRepository _updateEmailContactRepository;

        public UpdateContactCommandHandler(IUpdateContactRepository updateContactRepository, IUpdatePhoneContactRepository updatePhoneContactRepository, IUpdateEmailContactRepository updateEmailContactRepository)
        {
            _updateContactRepository = updateContactRepository;
            _updatePhoneContactRepository = updatePhoneContactRepository;
            _updateEmailContactRepository = updateEmailContactRepository;
        }
        private async void UpdateContactPhones(List<UpdatePhoneContactModelDTO> requestPhones)
        {
            List<UpdatePhoneContactModelDTO> requestPhonesContact = requestPhones;

            if (requestPhonesContact.Count() == 0) throw new ValidationException("Favor de ingresar un telefono");

            if (requestPhonesContact.Count() > 0)
            {
                foreach (var item in requestPhonesContact)
                {
                    PhoneContactModel modelPhoneContact = new()
                    {
                        fechaModificacion = DateTime.Now,
                        telefono = item.telefono,
                        Id = item.Id
                    };

                    var resultPhoneContact = await _updatePhoneContactRepository.UpdatePhoneContact(modelPhoneContact);

                    if (resultPhoneContact <= 0) throw new ValidationException("Ocurrio un error al actualizar el telefono");

                }
            }
        }
        private async void UpdateContactEmails(List<UpdateEmailContactModelDTO> requestEmail)
        {
            List<UpdateEmailContactModelDTO> requestEmailsContact = requestEmail;

            if (requestEmailsContact.Count() == 0) throw new ValidationException("Favor de ingresar un email");

            if (requestEmailsContact.Count() > 0)
            {
                foreach (var item in requestEmailsContact)
                {

                    EmailContactModel modelEmailContact = new()
                    {
                        fechaModificacion = DateTime.Now,
                        email = item.email,
                        Id = item.Id

                    };

                    var resultEmailContact = await _updateEmailContactRepository.UpdateEmailContact(modelEmailContact);

                    if (resultEmailContact <= 0) throw new ValidationException("Ocurrio un error al actualizar el email");

                }
            }
        }

        public async Task<int> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            ContactModel model = new()
            {
                Id = request.Id,
                tipoContacto_parametro = request.tipoContacto_parametro,
                areaContacto_parametro = request.areaContacto_parametro,
                nombreCompleto = request.nombreCompleto,
                comentario = request.comentario,
                fechaActualizacion = DateTime.Now
            };

            var resultContact = await _updateContactRepository.UpdateContact(model);


            if (resultContact <= 0) throw new ValidationException("Ocurrio un error al actualizar el contacto");


            UpdateContactPhones(request.telefonosContacto);
            UpdateContactEmails(request.emailscontacto);


            return model.Id;
        }
    }

}
