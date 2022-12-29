using MediatR;
using Scharff.Domain.Entities;
using Scharff.Infrastructure.Repositories.Contact.RegisterContact;
using Scharff.Infrastructure.Repositories.Contact.RegisterEmailContact;
using Scharff.Infrastructure.Repositories.Contact.RegisterPhoneContact;
using System.ComponentModel.DataAnnotations;

namespace Scharff.Application.Commands.Contact.RegisterContact
{
    public class RegisterContactCommandHandler : IRequestHandler<RegisterContactCommand, int>
    {
        private readonly IRegisterContactRepository _registerContactRepository;
        private readonly IRegisterPhoneContactRepository _registerPhoneContactRepository;
        private readonly IRegisterEmailContactRepository _registerEmailContactRepository;


        public RegisterContactCommandHandler(IRegisterContactRepository registerContactRepository, IRegisterPhoneContactRepository registerPhoneContactRepository, IRegisterEmailContactRepository registerEmailContactRepository)
        {
            _registerContactRepository = registerContactRepository;
            _registerPhoneContactRepository = registerPhoneContactRepository;
            _registerEmailContactRepository = registerEmailContactRepository;
        }
        private async void RegisterContactPhones(int resultContact, List<RegisterPhoneContactModelDTO> requestPhones)
        {
            List<RegisterPhoneContactModelDTO> requestPhonesContact = requestPhones;

            if (requestPhonesContact.Count() == 0) throw new ValidationException("Favor de ingresar un telefono");

            if (requestPhonesContact.Count() > 0)
            {
                foreach (var item in requestPhonesContact)
                {
                    PhoneContactModel modelPhoneContact = new()
                    {
                        fechaCreacion = DateTime.Now,
                        idContacto = resultContact,
                        telefono = item.telefono
                    };

                    var resultPhoneContact = await _registerPhoneContactRepository.RegisterPhoneContact(modelPhoneContact);

                    if (resultPhoneContact <= 0) throw new ValidationException("Ocurrio un error al insertar el telefono");

                }
            }
        }
        private async void RegisterContactEmails(int resultContact, List<RegisterEmailContactModelDTO> requestEmail)
        {
            List<RegisterEmailContactModelDTO> requestEmailsContact = requestEmail;

            if (requestEmailsContact.Count() == 0) throw new ValidationException("Favor de ingresar un email");

            if (requestEmailsContact.Count() > 0)
            {
                foreach (var item in requestEmailsContact)
                {

                    EmailContactModel modelEmailContact = new()
                    {
                        fechaCreacion = DateTime.Now,
                        idContacto = resultContact,
                        email = item.email
                    };

                    var resultEmailContact = await _registerEmailContactRepository.RegisterEmailContact(modelEmailContact);

                    if (resultEmailContact <= 0) throw new ValidationException("Ocurrio un error al insertar el email");

                }
            }
        }

        public async Task<int> Handle(RegisterContactCommand request, CancellationToken cancellationToken)
        {
            ContactModel model = new()
            {
                estado = true,
                idCliente = request.idCliente,
                tipoContacto_parametro = request.tipoContacto_parametro,
                areaContacto_parametro = request.areaContacto_parametro,
                nombreCompleto = request.nombreCompleto,
                comentario = request.comentario,
                fechaCreacion = DateTime.Now,
                fechaInicio = DateTime.Now,

            };

            var resultContact = await _registerContactRepository.RegisterContact(model);

            if (resultContact <= 0) throw new ValidationException("Ocurrio un error al insertar el contacto");

            if (resultContact > 0)
            {
                RegisterContactPhones(resultContact, request.telefonosContacto);
                RegisterContactEmails(resultContact, request.emailscontacto);

            }

            return resultContact;
        }

    }
}
