using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scharff.API.Utils.Models;
using Scharff.Application.Commands.Direction.RegisterDirection;
using Scharff.Application.Queries.Direction.GetDirectionById;
using Scharff.Domain.Entities;
using Swashbuckle.AspNetCore.Annotations;

namespace Scharff.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AddressController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(template: "{id}")]
        [SwaggerResponse(200, "Retorna una direccion en base a su id cliente", typeof(DirectionModel))]
        [SwaggerResponse(204, "No se encontro el contacto")]
        [SwaggerResponse(400, "Ocurrio un error de validacion")]
        public async Task<IActionResult> GetAddressByIdClient(int idClient)
        {

            GetDirectionByIdQuery request = new() { Id = idClient };

            var result = await _mediator.Send(request);
            return Ok(new CustomResponse<List<DirectionModel>>($"Se encontraron las direcciones con el id cliente: {idClient}.", result));
        }

        [HttpPost]
        [SwaggerOperation("Registrar direccion")]
        public async Task<IActionResult> RegisterDirection([FromBody] RegisterDirectionCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(new CustomResponse<int>($"Se inserto la direccion con id: {result}.", result));
        }
    }
}
