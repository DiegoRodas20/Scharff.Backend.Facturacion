namespace Scharff.Domain.Entities
{
    public class AddressModel
    {      

        public int Id { get; set; }
        public Boolean? Status { get; set; }
        public int TypeDirectionParameter { get; set; }
        public int IdClient { get; set; }
        public int? IdUbigeo { get; set; }
        public string Direction { get; set; }
        public string PostalCode { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? AuthorCreation { get; set; }
        public DateTime? DateUpdate { get; set; }
        public int? AuthorUpdate { get; set; }
    }
}
