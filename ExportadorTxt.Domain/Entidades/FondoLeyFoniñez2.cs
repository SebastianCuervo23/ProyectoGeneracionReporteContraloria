using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportadorTxt.Domain.Entidades
{
    public class FondoLeyFoniñez2
    {
        public string PeriodoReportado { get; set; } = string.Empty;
        public string IdCcf { get; set; } = string.Empty;
        public string NombreCcf { get; set; } = string.Empty;
        public string TipoBeneficiario { get; set; } = string.Empty;
        public string TipoDocumentoBeneficiario { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public DateTime? FechaNacimientoBeneficiario { get; set; }
        public string CiudadNacimientoBeneficiario { get; set; } = string.Empty;
        public DateTime? FechaVinculacionBeneficiario { get; set; }
        public string CiudadResidenciaBeneficiario { get; set; } = string.Empty;
        public string AreaGeografica { get; set; } = string.Empty;
        public string DireccionResidencia { get; set; } = string.Empty;
        public string TipoDocumentoAcudiente { get; set; } = string.Empty;
        public string NumeroDocumentoAcudiente { get; set; } = string.Empty;
        public string PrimerNombreAcudiente { get; set; } = string.Empty;
        public string SegundoNombreAcudiente { get; set; } = string.Empty;
        public string PrimerApellidoAcudiente { get; set; } = string.Empty;
        public string SegundoApellidoAcudiente { get; set; } = string.Empty;
        public string TelefonoAcudiente { get; set; } = string.Empty;
        public string ModalidadAin { get; set; } = string.Empty;
        public string Infraestructura { get; set; } = string.Empty;
        public string IdInfraestructura { get; set; } = string.Empty;
        public string NombreColegio { get; set; } = string.Empty;
        public string NombreCompletoEstudiante { get; set; } = string.Empty;
        public string NumeroDocumentoEstudiante { get; set; } = string.Empty;
        public string PrimerApellidoBeneficiario { get; set; } = string.Empty;
        public string PrimerNombreBeneficiario { get; set; } = string.Empty;
        public string SegundoApellidoBeneficiario { get; set; } = string.Empty;
        public string SegundoNombreBeneficiario { get; set; } = string.Empty;
        public string ModalidadPrestacionServiciosSociales { get; set; } = string.Empty;
        public string PaisNacimiento { get; set; } = string.Empty;
        public string CodigoPaisNacimiento { get; set; } = string.Empty;
        public string Etnia { get; set; } = string.Empty;
        public string FactorVulnerabilidad { get; set; } = string.Empty;
        public string Poblaciones { get; set; } = string.Empty;
    }
}
