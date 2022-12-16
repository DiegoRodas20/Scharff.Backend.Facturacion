using MediatR;
using Microsoft.AspNetCore.Mvc;
using Scharff.Application.Queries.Client.GetAllClient;
using Scharff.Application.Queries.Client.GetClientById;
using Scharff.Application.Queries.Client.UpdateClientStatus;
using Scharff.Domain.Entities;
using Swashbuckle.AspNetCore.Annotations;

namespace Scharff.API.Controllers
{
    [Route("api/[controller]")]
    public class ClientController : Controller
    {
        private readonly IMediator _mediator;
        public ClientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [SwaggerResponse(200, "Retorna los clientes por Id", typeof(ClientModel))]
        [SwaggerResponse(204, "No se encontró el cliente seleccionado")]
        [SwaggerResponse(400, "Ocurrio un error de validacion")]
        public async Task<IActionResult> GetClientByID(int idClient)
        {
            var result = await _mediator.Send(new GetClientByIdQuery());

            if (result == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpGet]
        [SwaggerResponse(200, "Retorna todos los clientes", typeof(ClientModel))]
        [SwaggerResponse(204, "No se encontró el cliente")]
        [SwaggerResponse(400, "Ocurrio un error de validacion")]
        public async Task<IActionResult> GetAllClient()
        {
            var result = await _mediator.Send(new GetAllClientQuery());

            if (result == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpGet]
        [SwaggerResponse(200, "Habilitar / Deshabilitar Clientes", typeof(ClientModel))]
        [SwaggerResponse(204, "No se encontró el cliente")]
        [SwaggerResponse(400, "Ocurrio un error de validacion")]
        public async Task<IActionResult> UpdateClientStatus(int idClient)
        {
            var result = await _mediator.Send(new UpdateClientStatusQuery());

            if (result == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(result);
            }
        }
    }
}
