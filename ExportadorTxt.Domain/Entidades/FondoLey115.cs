using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportadorTxt.Domain.Entidades
{
    public class FondoLey115
    {
        public string MesReporte { get; set; } = string.Empty;
        public int IdCcf { get; set; }
        public string NombreCcf { get; set; } = string.Empty;
        public string TipoDocumentoAfiliado { get; set; } = string.Empty;
        public string NumeroIdentificacionAfiliado { get; set; } = string.Empty;
        public string TipoDocumentoBeneficiario { get; set; } = string.Empty;
        public string NumeroIdentificacionBeneficiario { get; set; } = string.Empty;
        public string IdColegio { get; set; } = string.Empty;
        public string NombreColegio { get; set; } = string.Empty;
        public string GradoEscolaridad { get; set; } = string.Empty;
        public string TipoSubsidio { get; set; } = string.Empty;
        public decimal ValorSubsidio { get; set; }
        public string CodigoInfraestructura { get; set; } = string.Empty;
        public string NombreInfraestructura { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
    }
}
