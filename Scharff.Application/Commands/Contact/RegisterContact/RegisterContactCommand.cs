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
        public List<RegisterPhoneContactModel> phones_contact { get; set; }
        public List<RegisterEmailContactModel> emails_contact { get; set; }

    }
    public class RegisterPhoneContactModel
    {
        public string phone { get; set; }

    }
    public class RegisterEmailContactModel
    {
        public string email { get; set; }

    }
}
