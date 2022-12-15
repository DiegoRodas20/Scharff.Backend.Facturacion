using MediatR;
using Microsoft.AspNetCore.Mvc;
using Scharff.Application.Queries.Client.GetClientById;
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
        [SwaggerResponse(200, "Retorna los clientes", typeof(ClientModel))]
        [SwaggerResponse(204, "No se encontraron clientes")]
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
    }
}
