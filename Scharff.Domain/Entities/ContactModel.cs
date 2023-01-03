namespace Scharff.Domain.Entities
{
    public class ContactModel
    {
        public int Id { get; set; }
        public bool? status { get; set; }
        public int client_id { get; set; }
        public int type_param { get; set; }
        public int area_param { get; set; }
        public string? full_name { get; set; }
        public string? comment { get; set; }
        public DateTime? creation_date { get; set; }
        public int creation_author { get; set; }
        public DateTime? modification_date { get; set; }
        public int modification_author { get; set; }
        public DateTime? start_date { get; set; }
        public DateTime? end_date { get; set; }
        public string telephone { get; set; }
        public string email { get; set; }


        //Descripciones tabla Parametro
        public string description_type_contact { get; set; }
        public string description_area_contact { get; set; }

        public List<GetPhoneContactModelDTO> phones_contact { get; set; }

        public List<GetEmailContactModelDTO> emails_contact { get; set; }

        public class GetPhoneContactModelDTO
        {
            public int Id { get; set; }
            public string telephone { get; set; }

        }
        public class GetEmailContactModelDTO
        {
            public int Id { get; set; }
            public string email { get; set; }

        }

    }
}
