using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportadorTxt.Domain.Entidades
{
    public class FondoLeyFoniñez
    {
        public string Mes { get; set; } = string.Empty;
        public string IdCcf { get; set; } = string.Empty;
        public string NombreCcf { get; set; } = string.Empty;
        public string NombreCompleto { get; set; } = string.Empty;
        public string NumeroDocumento { get; set; } = string.Empty;
        public string TipoDocumento { get; set; } = string.Empty;
        public string IdConvenioJec { get; set; } = string.Empty;
        public string TipoJornada { get; set; } = string.Empty;
        public string ModalidadJec { get; set; } = string.Empty;
        public string Infraestructura { get; set; } = string.Empty;
        public string IdInfraestructura { get; set; } = string.Empty;
        public string CiudadInfraestructura { get; set; } = string.Empty;
        public string NombreColegio { get; set; } = string.Empty;
        public string IdColegio { get; set; } = string.Empty;
        public string ModalidadPrestacionServicioSocial { get; set; } = string.Empty;
        public string Etnia { get; set; } = string.Empty;
        public string Poblaciones { get; set; } = string.Empty;
        public string TipoBeneficiario { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public DateTime? FechaNacimientoBeneficiario { get; set; }
        public string DireccionResidencia { get; set; } = string.Empty;
        public string CiudadNacimiento { get; set; } = string.Empty;
        public string CiudadResidencia { get; set; } = string.Empty;
        public string AreaGeografica { get; set; } = string.Empty;
        public string PaisNacimiento { get; set; } = string.Empty;
        public string Sector { get; set; } = string.Empty;
    }
}
