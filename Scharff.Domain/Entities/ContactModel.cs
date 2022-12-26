﻿namespace Scharff.Domain.Entities
{
    public class ContactModel
    {
        public int id { get; set; }
        public bool? estado { get; set; }
        public int idCliente { get; set; }
        public int tipoContacto_parametro { get; set; }
        public int areaContacto_parametro { get; set; }
        public string? nombreCompleto { get; set; }
        public string? comentario { get; set; }
        public DateTime? fechaCreacion { get; set; }
        public int autorCreacion { get; set; }
        public DateTime? fechaActualizacion { get; set; }
        public int autorActualizacion { get; set; }
        public DateTime? fechaInicio { get; set; }
        public DateTime? fechaFin { get; set; }

    }
}
