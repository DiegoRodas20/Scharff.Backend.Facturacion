using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scharff.API.Utils.Models;
using Scharff.Application.Commands.Direction.DeleteDirection;
using Scharff.Application.Commands.Direction.RegisterDirection;
using Scharff.Application.Commands.Direction.UpdateDirection;
using Scharff.Application.Queries.Address.GetAddressByIdClient;
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

        [HttpGet(template: "GetList/{idClient}")]
        [SwaggerResponse(200, "Retorna una direccion en base a su id cliente", typeof(AddressModel))]
        [SwaggerResponse(204, "No se encontro direcciones")]
        [SwaggerResponse(400, "Ocurrio un error de validacion")]
        public async Task<IActionResult> GetAddressByIdClient(int idClient)
        {

            GetAddressByIdClientQuery request = new() { client_id = idClient };

            var result = await _mediator.Send(request);
            return Ok(new CustomResponse<List<AddressModel>>($"Se encontraron las direcciones con el id cliente: {idClient}.", result));
        }

        [HttpPost]        
        [SwaggerOperation("Registrar direccion")]
        public async Task<IActionResult> RegisterDirection([FromBody] RegisterAddressCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(new CustomResponse<int>($"Se inserto la direccion con id: {result}.", result));
        }


        [HttpGet(template: "{id}")]
        [SwaggerResponse(200, "Retorna datos de direccion en base a su id ", typeof(DirectionModel))]
        [SwaggerResponse(204, "No se encontro la direccion")]
        [SwaggerResponse(400, "Ocurrio un error de validacion")]
        public async Task<IActionResult> GetAddressById(int id)
        {

            GetAddressByIdQuery request = new() { id = id };

            var result = await _mediator.Send(request);
            return Ok(new CustomResponse<List<AddressModel>>($"Se encontraron los datos de la direccion con el id : {id}.", result));
        }

        [HttpPut(template: "{id}")]
        [SwaggerOperation("Actualizar direccion")]
        public async Task<IActionResult> UpdateDirection(int id, [FromBody] UpdateAddressCommand request)
        {
            request.id = id;
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpDelete(template: "{id}")]
        [SwaggerOperation("Eliminar direccion")]
        public async Task<IActionResult> DeleteDirection(int id, [FromBody] DeleteAddressCommand request)
        {
            request.Id = id;
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
