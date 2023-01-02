namespace Scharff.Domain.Entities
{
    public class PhoneContactModel
    {
        public int Id { get; set; }
        public string telephone { get; set; }
        public int contact_id { get; set; }
        public DateTime creation_date { get; set; }

        public int? creation_author { get; set; }

        public DateTime? modification_date { get; set; }
        public int? modification_author { get; set; }


    }
}
