namespace Scharff.Domain.Entities
{
    public class PhoneContactModel
    {
        public int Id { get; set; }
        public string telefono { get; set; }
        public int idContacto { get; set; }
        public DateTime fechaCreacion { get; set; }

        //public int? autorCreacion { get; set; }

        public DateTime? fechaModificacion { get; set; }
        //public int? autorModificacion { get; set; }


    }
}
