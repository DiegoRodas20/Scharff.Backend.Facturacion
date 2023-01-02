using MediatR;
using Microsoft.AspNetCore.Mvc;
using Scharff.API.Utils.Models;
using Scharff.Application.Commands.Client.DisableClient;
using Scharff.Application.Commands.Client.EnableClient;
using Scharff.Application.Commands.Client.RegisterClient;
using Scharff.Application.Commands.Client.UpdateClient;
using Scharff.Application.Queries.Client.GetAllClients;
using Scharff.Application.Queries.Client.GetClientById;
using Scharff.Domain.Entities;
using Swashbuckle.AspNetCore.Annotations;

namespace Scharff.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ClientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [SwaggerResponse(200, "Retorna el listado general de clientes", typeof(CustomResponse<List<ClientModel>>))]
        [SwaggerResponse(204, "No se encontraron clientes")]
        [SwaggerResponse(400, "Ocurrio un error de validacion")]
        public async Task<IActionResult> GetAllClients()

        {
            var result = await _mediator.Send(new GetAllClientsQuery());

            if (result == null)
            {
                throw new Exception("No se encontraron clientes.");
            }
            else
            {

                return Ok(new CustomResponse<List<ClientModel>>(
                    $"Se encontraron {result.Count} clientes.",
                    result
                    ));
            }
        }

        [HttpGet(template: "{idClient}")]
        [SwaggerResponse(200, "Retorna un cliente en base a su ID", typeof(CustomResponse<ClientModel>))]
        [SwaggerResponse(204, "No se encontro el cliente")]
        [SwaggerResponse(400, "Ocurrio un error de validacion")]
        public async Task<IActionResult> GetClientByID(int idClient)
        {
            GetClientByIdQuery request = new() { IdClient = idClient };

            var result = await _mediator.Send(request);
            return Ok(new CustomResponse<ClientModel>($"Se encontro el cliente con id: {idClient}.", result));
        }

        [HttpPost]
        [SwaggerOperation("Registrar cliente")]
        public async Task<IActionResult> RegisterClient([FromBody] RegisterClientCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(new CustomResponse<int>($"Se inserto el cliente con id: {result}.", result));
        }


        [HttpPut(template: "{idClient}")]
        [SwaggerOperation("Actualizar Cliente")]
        public async Task<IActionResult> UpdateClient(int idClient, [FromBody] UpdateClientCommand request)
        {
            request.id = idClient;
            var result = await _mediator.Send(request);
            return Ok(new CustomResponse<int>($"Se actualizo el cliente con id: {idClient}.", result));
        }


        [HttpPut("disable/{idClient}")]
        [SwaggerOperation("Inhabilitar Cliente")]
        public async Task<IActionResult> DisableClient(int idClient)
        {
            DisableClientCommand request = new() { IdClient = idClient };
            var result = await _mediator.Send(request);
            return Ok(new CustomResponse<int>($"Se inhabilito el cliente con id: {idClient}.", result));
        }


        [HttpPut(template: "enable/{idClient}")]
        [SwaggerOperation("Habilitar Cliente")]
        public async Task<IActionResult> EnableClient(int idClient)
        {
            EnableClientCommand request = new() { IdClient = idClient };
            var result = await _mediator.Send(request);
            return Ok(new CustomResponse<int>($"Se habilito el cliente con id: {idClient}.", result));
        }


        //[HttpPost]
        //[SwaggerOperation("Validar cliente")]
        //public async Task<IActionResult> ValidateClient([FromBody] RegisterClientCommand request)
        //{
        //    var result = await _mediator.Send(request);
        //    return Ok(result);
        //}

    }
}
