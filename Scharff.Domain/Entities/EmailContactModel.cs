namespace Scharff.Domain.Entities
{
    public class EmailContactModel
    {
        public int Id { get; set; }
        public string email { get; set; }
        public int idContacto { get; set; }
        public DateTime fechaCreacion { get; set; }

        //public int? autorCreacion { get; set; }

        public DateTime? fechaModificacion { get; set; }
        //public int? autorModificacion { get; set; }
    }
}
