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
    public class RegisterDirectionCommandHandler : IRequestHandler<RegisterDirectionCommand, int>
    {
        private readonly IRegisterDirectionRepository _registerDirectionRepository;
        public RegisterDirectionCommandHandler(IRegisterDirectionRepository registerDirectionRepository)
        {
            _registerDirectionRepository = registerDirectionRepository;
        }

        public async Task<int> Handle(RegisterDirectionCommand request, CancellationToken cancellationToken)
        {

            DirectionModel model = new()
            {
                TypeDirectionParameter = request.tipoDireccion_parametro,
                IdClient = request.idCliente,
                Direction = request.direccion,
            };

            var result = await _registerDirectionRepository.RegisterDirection(model);
            return result;
        }
    }
}
