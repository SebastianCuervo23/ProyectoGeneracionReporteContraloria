using System;

namespace ExportadorTxt.Domain.Entidades
{
    public class FondoLeyFoniñez
    {
        public string WkMes { get; set; } = string.Empty;
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
        public string ModalidadPrestacionServiciosSociales { get; set; } = string.Empty;
        public string Etnia { get; set; } = string.Empty;
        public string Poblacion { get; set; } = string.Empty;
        public string TipoBeneficiario { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public DateTime? FechaNacimientoBeneficiario { get; set; }
        public string DireccionResidenciaBeneficiario { get; set; } = string.Empty;
        public string CiudadNacimientoBeneficiario { get; set; } = string.Empty;
        public string CiudadResidenciaBeneficiario { get; set; } = string.Empty;
        public string AreaGeografica { get; set; } = string.Empty;
        public string PaisNacimientoBeneficiario { get; set; } = string.Empty;
        public string Sector { get; set; } = string.Empty;
    }
}