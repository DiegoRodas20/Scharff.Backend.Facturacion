namespace Scharff.Domain.Entities
{
    public class AddressModel
    {
        public int id { get; set; }
        public bool estado { get; set; }
        public int tipoDireccion_parametro { get; set; }
        public int idCliente { get; set; }
        public int idUbigeo { get; set; }
        public string? direccion { get; set; }
        public string? codigoPostal { get; set; }
        public DateTime fechaCreacion { get; set; }
        public int autorCreacion { get; set; }
        public DateTime fechaModificacion { get; set; }
        public int autorModificacion { get; set; }
    }
}
