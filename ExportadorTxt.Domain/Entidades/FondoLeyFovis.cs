using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportadorTxt.Domain.Entidades
{
    public class FondoLeyFovis
    {
        public string PeriodoReportado { get; set; } = string.Empty;
        public string IdCcf { get; set; } = string.Empty;
        public string NombreCcf { get; set; } = string.Empty;
        public string AnioAsignacion { get; set; } = string.Empty;
        public string ComponenteVivienda { get; set; } = string.Empty;
        public string EstadoSubsidio { get; set; } = string.Empty;
        public string DescEstadoSubsidio { get; set; } = string.Empty;
        public string NumIdentificaAfiliado { get; set; } = string.Empty;
        public string NumIdentificacionIntegranteHogar { get; set; } = string.Empty;
        public string PlanVivienda { get; set; } = string.Empty;
        public string PrimerApellido { get; set; } = string.Empty;
        public string PrimerNombre { get; set; } = string.Empty;
        public string SegundoApellido { get; set; } = string.Empty;
        public string SegundoNombre { get; set; } = string.Empty;
        public string TitularSubsidio { get; set; } = string.Empty;
        public string SubsidioHogar { get; set; } = string.Empty;
        public string Parentesco { get; set; } = string.Empty;
        public string RangoIngresoFamiliar { get; set; } = string.Empty;
        public string EntidadFuenteFinanciamiento { get; set; } = string.Empty;
        public string TipoDocumento { get; set; } = string.Empty;
        public string TipoDocumentoIntegranteHogar { get; set; } = string.Empty;
        public decimal? IngresoIntegranteHogar { get; set; }
        public decimal? ValorSubsidio { get; set; }
    }
}
