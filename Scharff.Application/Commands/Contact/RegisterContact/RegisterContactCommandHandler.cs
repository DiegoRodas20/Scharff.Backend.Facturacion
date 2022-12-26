using MediatR;
using Scharff.Application.Commands.Client.RegisterClient;
using Scharff.Domain.Entities;
using Scharff.Infrastructure.Repositories.Client.RegisterClient;
using Scharff.Infrastructure.Repositories.Contact.RegisterContact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scharff.Application.Commands.Contact.RegisterContact
{
    public class RegisterContactCommandHandler : IRequestHandler<RegisterContactCommand, int>
    {
        private readonly IRegisterContactRepository _registerContactRepository;
        public RegisterContactCommandHandler(IRegisterContactRepository registerContactRepository)
        {
            _registerContactRepository = registerContactRepository;
        }
        public async Task<int> Handle(RegisterContactCommand request, CancellationToken cancellationToken)
        {

            ContactModel model = new()
            {
                idCliente = request.idCliente,
                tipoContacto_parametro = request.tipoContacto_parametro,
                areaContacto_parametro = request.areaContacto_parametro,
                nombreCompleto = request.nombreCompleto,
                comentario = request.comentario,
            };

            var result = await _registerContactRepository.RegisterContact(model);
            return result;
        }

    }
}
