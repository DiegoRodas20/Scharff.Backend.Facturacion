using MediatR;
using Scharff.Application.Commands.Contact.RegisterContact;
using Scharff.Domain.Entities;
using Scharff.Infrastructure.Repositories.Contact.RegisterContact;
using Scharff.Infrastructure.Repositories.Contact.UpdateContact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scharff.Application.Commands.Contact.UpdateContact
{
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, ResponseModel>
    {
        private readonly IUpdateContactRepository _updateContactRepository;
        public UpdateContactCommandHandler(IUpdateContactRepository updateContactRepository)
        {
            _updateContactRepository = updateContactRepository;
        }

        public async Task<ResponseModel> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            ContactModel model = new()
            {
                id=request.Id,
                estado = request.Status,
                idCliente = request.IdClient,
                tipoContacto_parametro = request.TypeContactParameter,
                areaContacto_parametro = request.AreaContactParameter,
                nombreCompleto = request.FullName,
                comentario = request.Commentary,
                fechaCreacion = request.CreationDate,
                autorCreacion = request.AuthorCreation,
                fechaActualizacion = request.DateUpdate,
                autorActualizacion = request.AuthorUpdate,
                fechaInicio = request.StartDate,
                fechaFin = request.EndDate

            };

            var result = await _updateContactRepository.UpdateContact(model);
            return result;
        }
    }
    
}
