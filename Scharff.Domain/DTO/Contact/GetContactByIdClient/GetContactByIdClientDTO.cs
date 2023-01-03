using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scharff.Domain.DTO.Contact.GetContactByIdClient
{
    public class GetContactByIdClientDTO
    {
        public int Id { get; set; }
        public bool? status { get; set; }
        public int client_id { get; set; }
        public string? full_name { get; set; }
        public string? comment { get; set; }
        public DateTime? creation_date { get; set; }
        public DateTime? modification_date { get; set; }
        public string telephone { get; set; }
        public string email { get; set; }

        public string description_type_contact { get; set; }
        public string description_area_contact { get; set; }


    }
}
