using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportadorTxt.Domain.Entidades
{
    public class Contratos
    {
        public string PeriodoReportado { get; set; } = string.Empty;
        public string IdCcf { get; set; } = string.Empty;
        public string NombreCcf { get; set; } = string.Empty;
        public string NumeroContratoConvenio { get; set; } = string.Empty;
        public string IdCentroCosto { get; set; } = string.Empty;
        public string NombreCentroCosto { get; set; } = string.Empty;
        public DateTime? FechaFirmaContrato { get; set; }
        public string NumeroActaConsejoDirectivo { get; set; } = string.Empty;
        public string NombreContratante { get; set; } = string.Empty;
        public string CargoContratante { get; set; } = string.Empty;
        public string NombreContratista { get; set; } = string.Empty;
        public string IdentificacionContratista { get; set; } = string.Empty;
        public string IdNaturalezaContrato { get; set; } = string.Empty;
        public string NaturalezaContrato { get; set; } = string.Empty;
        public string IdClaseContrato { get; set; } = string.Empty;
        public string ClaseContrato { get; set; } = string.Empty;
        public string ObjetoContrato { get; set; } = string.Empty;
        public DateTime? FechaInicioContrato { get; set; }
        public DateTime? FechaFinContrato { get; set; }
        public decimal? ValorInicialContrato { get; set; }
        public decimal? ValorAdicion1Contrato { get; set; }
        public decimal? ValorAporteCcf { get; set; }
        public decimal? ValorAporteCooperante { get; set; }
        public string TipoAporteCooperante { get; set; } = string.Empty;
        public string TipoAporteSSF { get; set; } = string.Empty;
        public string InterventorSupervisor { get; set; } = string.Empty;
        public string CargoSupervisorInterventor { get; set; } = string.Empty;
        public DateTime? FechaActaLiquidacion { get; set; }
        public decimal? PorcentajeAnticipo { get; set; }
        public decimal? AnticipoContrato { get; set; }
        public bool? AnticipoLegalizado { get; set; }
        public string EstadoContrato { get; set; } = string.Empty;
    }
}
