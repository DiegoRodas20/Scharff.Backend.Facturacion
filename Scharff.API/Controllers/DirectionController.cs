using MediatR;
using Microsoft.AspNetCore.Mvc;
using Scharff.Application.Commands.Contact.DeleteContact;
using Scharff.Application.Commands.Contact.RegisterContact;
using Scharff.Application.Commands.Contact.UpdateContact;
using Scharff.Application.Commands.Direction.DeleteDirection;
using Scharff.Application.Commands.Direction.RegisterDirection;
using Scharff.Application.Commands.Direction.UpdateDirection;
using Scharff.Application.Queries.Contact.GetContactoById;
using Scharff.Application.Queries.Direction.GetDirectionById;
using Scharff.Domain.Entities;
using Swashbuckle.AspNetCore.Annotations;

namespace Scharff.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DirectionController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(template: "{id}")]
        [SwaggerResponse(200, "Retorna un contacto en base a su ID", typeof(DirectionModel))]
        [SwaggerResponse(204, "No se encontro el contacto")]
        [SwaggerResponse(400, "Ocurrio un error de validacion")]
        public async Task<IActionResult> GetDirectionByID(int id)
        {
            GetDirectionByIdQuery request = new() { Id = id };

            var result = await _mediator.Send(request);

            if (result == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(result);
            }
        }
        [HttpPost]
        [SwaggerOperation("Registrar direccion")]
        public async Task<IActionResult> RegisterDirection([FromBody] RegisterDirectionCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        [HttpPut(template: "{id}")]
        [SwaggerOperation("Actualizar direccion")]
        public async Task<IActionResult> UpdateDirection(int id, [FromBody] UpdateDirectionCommand request)
        {
            request.Id = id;
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpDelete(template: "{id}")]
        [SwaggerOperation("Eliminar direccion")]
        public async Task<IActionResult> DeleteDirection(int id, [FromBody] DeleteDirectionCommand request)
        {
            request.Id = id;
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }

}
