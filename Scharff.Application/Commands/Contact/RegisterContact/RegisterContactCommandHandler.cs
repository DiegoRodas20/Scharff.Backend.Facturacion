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
    public class RegisterContactCommandHandler : IRequestHandler<RegisterContactCommand, ResponseModel>
    {
        private readonly IRegisterContactRepository _registerContactRepository;
        public RegisterContactCommandHandler(IRegisterContactRepository registerContactRepository)
        {
            _registerContactRepository = registerContactRepository;
        }
        public async Task<ResponseModel> Handle(RegisterContactCommand request, CancellationToken cancellationToken)
        {

        ContactModel model = new()
            {
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

            var result = await _registerContactRepository.RegisterContact(model);
            return result;
        }
    }
}
