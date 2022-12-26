using MediatR;
using Scharff.Application.Commands.Contact.DeleteContact;
using Scharff.Domain.Entities;
using Scharff.Infrastructure.Repositories.Contact.DeleteContact;
using Scharff.Infrastructure.Repositories.Direction.DeleteDirection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scharff.Application.Commands.Direction.DeleteDirection
{
    public class DeleteDirectionCommandHandler : IRequestHandler<DeleteContactCommand, ResponseModel>
    {
        private readonly IDeleteDirectionRepository _deleteDirectionRepository;
        public DeleteDirectionCommandHandler(IDeleteDirectionRepository deleteDirectionRepository)
        {
            _deleteDirectionRepository = deleteDirectionRepository;
        }
        public async Task<ResponseModel> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            ContactModel model = new()
            {
                id = request.Id
            };

            var result = await _deleteDirectionRepository.DeleteDirection(model.id);
            return result;
        }
    }
}
