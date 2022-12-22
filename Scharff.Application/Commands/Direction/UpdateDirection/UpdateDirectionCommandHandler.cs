using MediatR;
using Scharff.Application.Commands.Contact.UpdateContact;
using Scharff.Domain.Entities;
using Scharff.Infrastructure.Repositories.Contact.UpdateContact;
using Scharff.Infrastructure.Repositories.Direction.UpdateDirection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scharff.Application.Commands.Direction.UpdateDirection
{
    public class UpdateDirectionCommandHandler : IRequestHandler<UpdateDirectionCommand, ResponseModel>
    {
        private readonly IUpdateDirectionRepository _updateDirectionRepository;
        public UpdateDirectionCommandHandler(IUpdateDirectionRepository updateDirectionRepository)
        {
            _updateDirectionRepository = updateDirectionRepository;
        }
        public async Task<ResponseModel> Handle(UpdateDirectionCommand request, CancellationToken cancellationToken)
        {
            DirectionModel model = new()
            {
                Id=request.Id,
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

            var result = await _updateDirectionRepository.UpdateDirection(model);
            return result;
        }
    }
}
