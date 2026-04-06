using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportadorTxt.Domain.Entidades
{
    public class FondoLeyFosfec
    {
        public string PeriodoReportado { get; set; } = string.Empty;
        public string IdCcf { get; set; } = string.Empty;
        public string NombreCcf { get; set; } = string.Empty;
        public string TipoDocumentoBeneficiario { get; set; } = string.Empty;
        public string NumeroDocumentoBeneficiario { get; set; } = string.Empty;
        public string PrimerNombreBeneficiario { get; set; } = string.Empty;
        public string SegundoNombreBeneficiario { get; set; } = string.Empty;
        public string PrimerApellidoBeneficiario { get; set; } = string.Empty;
        public string SegundoApellidoBeneficiario { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public DateTime? FechaNacimientoBeneficiario { get; set; }
        public DateTime? FechaRadicacionSolicitud { get; set; }
        public DateTime? FechaAprobacion { get; set; }
        public DateTime? FechaLiquidacion { get; set; }
        public DateTime? FechaReactivacion { get; set; }
        public DateTime? FechaSuspension { get; set; }
        public decimal? TotalBeneficioLiquidado { get; set; }
        public string AreaGeografica { get; set; } = string.Empty;
        public string DireccionResidencia { get; set; } = string.Empty;
        public string Etnia { get; set; } = string.Empty;
        public string Poblacion { get; set; } = string.Empty;
        public string FactorVulnerabilidad { get; set; } = string.Empty;
        public string CodigoCiudad { get; set; } = string.Empty;
        public string CiudadBeneficiario { get; set; } = string.Empty;
        public string BeneficiosEconomicos { get; set; } = string.Empty;
        public string ComponenteMpc { get; set; } = string.Empty;
    }
}
