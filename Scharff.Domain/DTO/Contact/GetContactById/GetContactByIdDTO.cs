using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Scharff.Domain.Entities.ContactModel;

namespace Scharff.Domain.DTO.Contact.GetContactById
{
    public class GetContactByIdDTO
    {
        public int Id { get; set; }
        public bool? status { get; set; }
        public int client_id { get; set; }
        public int type_param { get; set; }
        public int area_param { get; set; }
        public string? full_name { get; set; }
        public string? comment { get; set; }
        public DateTime? creation_date { get; set; }
        public DateTime? modification_date { get; set; }

        public List<GetPhoneContactModelDTO> phones_contact { get; set; }

        public List<GetEmailContactModelDTO> emails_contact { get; set; }

    }
}
