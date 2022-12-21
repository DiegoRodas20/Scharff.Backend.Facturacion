﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scharff.Application.Commands.Client.UpdateClient
{
    public class UpdateClientCommand
    {
        public int id { get; set; }
        public int tipoCliente_parametro { get; set; }
        public string? numeroDocumentoIdentidad { get; set; }
        public int codigoSegmentacion_parametro { get; set; }
        public int tipoDocumentoIdentidad { get; set; }
        public int idUbicacionGeografica { get; set; }
        public string? razonSocial { get; set; }
        public int codigoSector_parametro { get; set; }
        public string? telefono { get; set; }
        public string? cuentaFedex { get; set; }
        public bool cuentaAutorizadaFedex { get; set; }
        public DateTime fechaAutorizacionFedex { get; set; }
        public string? nombreComercial { get; set; }
        public string? comentario { get; set; }
        public int tipoMoneda_parametro { get; set; }
        public int grupoEmpresarial_parametro { get; set; }
        public int holding_parametro { get; set; }
        public string? codigoSap { get; set; }
        public bool estadoCliente { get; set; }
        public int estadoSap_parametro { get; set; }
        public int estadoSR_parametro { get; set; }
        public DateTime fechaCreacion { get; set; }
        public int autorCreacion { get; set; }
        public DateTime fechaModificacion { get; set; }
        public int autorModificacion { get; set; }
    }
}