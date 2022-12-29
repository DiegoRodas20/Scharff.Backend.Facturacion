using MediatR;

namespace Scharff.Application.Commands.Contact.UpdateContact
{
    public class UpdateContactCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int tipoContacto_parametro { get; set; }
        public int areaContacto_parametro { get; set; }
        public string? nombreCompleto { get; set; }
        public string? comentario { get; set; }
        public List<UpdatePhoneContactModelDTO> telefonosContacto { get; set; }

        public List<UpdateEmailContactModelDTO> emailscontacto { get; set; }

    }
    public class UpdatePhoneContactModelDTO
    {
        public int Id { get; set; }
        public string telefono { get; set; }

    }
    public class UpdateEmailContactModelDTO
    {
        public int Id { get; set; }
        public string email { get; set; }

    }

}
