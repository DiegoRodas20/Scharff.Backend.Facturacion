using MediatR;

namespace Scharff.Application.Commands.Contact.UpdateContact
{
    public class UpdateContactCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int type_param { get; set; }
        public int area_param { get; set; }
        public string? full_name { get; set; }
        public string? comment { get; set; }
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
