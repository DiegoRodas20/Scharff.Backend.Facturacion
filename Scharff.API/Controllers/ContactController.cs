using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Scharff.API.Utils.Models;
using Scharff.Application.Commands.Contact.DeleteContact;
using Scharff.Application.Commands.Contact.RegisterContact;
using Scharff.Application.Commands.Contact.UpdateContact;
using Scharff.Application.Queries.Contact.GetContactById;
using Scharff.Application.Queries.Contact.GetContactoById;
using Scharff.Domain.DTO.Contact.GetContactById;
using Scharff.Domain.DTO.Contact.GetContactByIdClient;
using Scharff.Domain.Entities;
using Swashbuckle.AspNetCore.Annotations;

namespace Scharff.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ContactController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;

        }
        [HttpGet(template: "all/{idClient}")]
        [SwaggerResponse(200, "Retorna un contacto en base a su ID", typeof(List<ContactModel>))]
        [SwaggerResponse(204, "No se encontro el contacto")]
        [SwaggerResponse(400, "Ocurrio un error de validacion")]
        public async Task<IActionResult> GetContactsByIdClient(int idClient)
        {
            GetContactByIdClientQuery request = new() { IdClient = idClient };

            var result = await _mediator.Send(request);
            var responseMapper = _mapper.Map<List<ContactModel>, List<GetContactByIdClientDTO>>(result);

            return Ok(new CustomResponse<List<GetContactByIdClientDTO>>($"Se encontraron los contactos con el id cliente: {idClient}.", responseMapper));
        }

        [HttpGet(template: "{id}")]
        [SwaggerResponse(200, "Retorna un contacto en base a su ID", typeof(ContactModel))]
        [SwaggerResponse(204, "No se encontro el contacto")]
        [SwaggerResponse(400, "Ocurrio un error de validacion")]
        public async Task<IActionResult> GetContactsById(int id)
        {
            GetContactByIdQuery request = new() { Id = id };

            var result = await _mediator.Send(request);
            var responseMapper = _mapper.Map<ContactModel, GetContactByIdDTO>(result);

            return Ok(new CustomResponse<GetContactByIdDTO>($"Se encontro el contacto: {id}.", responseMapper));
        }

        [HttpPost]
        [SwaggerOperation("Registrar contacto")]
        public async Task<IActionResult> RegisterContact([FromBody] RegisterContactCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(new CustomResponse<int>($"Se inserto el contacto con id: {result}.", result));
        }

        [HttpPut(template: "{id}")]
        [SwaggerOperation("Actualizar Contacto")]
        public async Task<IActionResult> UpdateContact(int id, [FromBody] UpdateContactCommand request)
        {
            request.Id = id;
            var result = await _mediator.Send(request);
            return Ok(new CustomResponse<int>($"Se actualizo el contacto con id: {result}.", result));
        }

        [HttpDelete(template: "{id}")]
        [SwaggerOperation("Eliminar Contacto")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var result = await _mediator.Send(new DeleteContactCommand() { Id = id });
            return Ok(new CustomResponse<int>($"Se elimino el contacto con id: {result}.", result));
        }
    }
}
