namespace Scharff.Domain.Entities
{
    public class EmailContactModel
    {
        public int Id { get; set; }
        public string email { get; set; }
        public int contact_id { get; set; }
        public DateTime creation_date { get; set; }

        public int? creation_author { get; set; }

        public DateTime? modification_date { get; set; }
        public int? modification_author { get; set; }
    }
}
