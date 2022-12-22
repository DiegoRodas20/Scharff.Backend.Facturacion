using MediatR;
using Scharff.Application.Commands.Contact.RegisterContact;
using Scharff.Domain.Entities;
using Scharff.Infrastructure.Repositories.Contact.RegisterContact;
using Scharff.Infrastructure.Repositories.Direction.RegisterDirection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scharff.Application.Commands.Direction.RegisterDirection
{
    public class RegisterDirectionCommandHandler : IRequestHandler<RegisterDirectionCommand, ResponseModel>
    {
        private readonly IRegisterDirectionRepository _registerDirectionRepository;
        public RegisterDirectionCommandHandler(IRegisterDirectionRepository registerDirectionRepository)
        {
            _registerDirectionRepository = registerDirectionRepository;
        }

        public async Task<ResponseModel> Handle(RegisterDirectionCommand request, CancellationToken cancellationToken)
        {

        DirectionModel model = new()
            {
            Status = request.Status,
            TypeDirectionParameter = request.TypeDirectionParameter,
            IdClient = request.IdClient,
            IdUbigeo = request.IdUbigeo,
            Direction = request.Direction,
            PostalCode = request.PostalCode,
            CreationDate = request.CreationDate,
            AuthorCreation = request.AuthorCreation,
            DateUpdate = request.DateUpdate,
            AuthorUpdate = request.AuthorUpdate

        };

            var result = await _registerDirectionRepository.RegisterDirection(model);
            return result;
        }
    }
}
