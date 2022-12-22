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
                Id=request.Id,
                Status = request.Status,
                IdClient = request.IdClient,
                TypeContactParameter = request.TypeContactParameter,
                AreaContactParameter = request.AreaContactParameter,
                FullName = request.FullName,
                Commentary = request.Commentary,
                CreationDate = request.CreationDate,
                AuthorCreation = request.AuthorCreation,
                DateUpdate = request.DateUpdate,
                AuthorUpdate = request.AuthorUpdate,
                StartDate = request.StartDate,
                EndDate = request.EndDate

            };

            var result = await _updateContactRepository.UpdateContact(model);
            return result;
        }
    }
    
}
