﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scharff.Application.Commands.Client.RegisterClient;
using Scharff.Application.Commands.Contact.DeleteContact;
using Scharff.Application.Commands.Contact.RegisterContact;
using Scharff.Application.Commands.Contact.UpdateContact;
using Scharff.Application.Queries.Client.GetClientById;
using Scharff.Application.Queries.Contact.GetContactoById;
using Scharff.Domain.Entities;
using Swashbuckle.AspNetCore.Annotations;

namespace Scharff.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ContactsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(template: "{idClient}")]
        [SwaggerResponse(200, "Retorna un contacto en base a su ID", typeof(ContactModel))]
        [SwaggerResponse(204, "No se encontro el contacto")]
        [SwaggerResponse(400, "Ocurrio un error de validacion")]
        public async Task<IActionResult> GetContactByID(int idClient)
        {
            GetContactByIdQuery request = new() { IdClient = idClient };

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
        [SwaggerOperation("Registrar contacto")]
        public async Task<IActionResult> RegisterContact([FromBody] RegisterContactCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        [HttpPut(template: "{id}")]
        [SwaggerOperation("Actualizar Contacto")]
        public async Task<IActionResult> UpdateContact(int id, [FromBody] UpdateContactCommand request)
        {
            request.Id = id;
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpDelete(template: "{id}")]
        [SwaggerOperation("Eliminar Contacto")]
        public async Task<IActionResult> DeleteContact(int id, [FromBody] DeleteContactCommand request)
        {
            request.Id = id;
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
