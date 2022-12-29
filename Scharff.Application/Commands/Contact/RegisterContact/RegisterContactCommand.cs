using MediatR;

namespace Scharff.Application.Commands.Contact.RegisterContact
{
    public class RegisterContactCommand : IRequest<int>
    {
        public int idCliente { get; set; }
        public int tipoContacto_parametro { get; set; }
        public int areaContacto_parametro { get; set; }
        public string? nombreCompleto { get; set; }
        public string? comentario { get; set; }

        public List<RegisterPhoneContactModelDTO> telefonosContacto { get; set; }

        public List<RegisterEmailContactModelDTO> emailscontacto { get; set; }


        //public int autorCreacion { get; set; }
        //public DateTime? fechaInicio { get; set; }
        //public DateTime? fechaFin { get; set; }

    }
    public class RegisterPhoneContactModelDTO
    {
        public string telefono { get; set; }

    }
    public class RegisterEmailContactModelDTO
    {
        public string email { get; set; }

    }
}
