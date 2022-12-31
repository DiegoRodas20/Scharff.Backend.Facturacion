using MediatR;

namespace Scharff.Application.Commands.Contact.RegisterContact
{
    public class RegisterContactCommand : IRequest<int>
    {
        public int client_id { get; set; }
        public int type_param { get; set; }
        public int area_param { get; set; }
        public string? full_name { get; set; }
        public string? comment { get; set; }

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
