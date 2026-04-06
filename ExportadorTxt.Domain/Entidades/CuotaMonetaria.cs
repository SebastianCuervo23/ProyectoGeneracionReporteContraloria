using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportadorTxt.Domain.Entidades
{
    public class CuotaMonetaria
    {
        public string FechaReporte { get; set; } = string.Empty;
        public int IdCcf { get; set; }
        public string NombreCcf { get; set; } = string.Empty;
        public string TipoDocumentoEmpresa { get; set; } = string.Empty;
        public string NumeroDocumentoEmpresa { get; set; } = string.Empty;
        public string TipoDocumentoAfiliado { get; set; } = string.Empty;
        public string NumeroDocumentoAfiliado { get; set; } = string.Empty;
        public string TipoDocumentoPersonaCargo { get; set; } = string.Empty;
        public string NumeroDocumentoPersonaCargo { get; set; } = string.Empty;
        public string PrimerNombrePersonaCargo { get; set; } = string.Empty;
        public string SegundoNombrePersonaCargo { get; set; } = string.Empty;
        public string PrimerApellidoPersonaCargo { get; set; } = string.Empty;
        public string SegundoApellidoPersonaCargo { get; set; } = string.Empty;
        public DateTime? FechaNacimientoPersonaCargo { get; set; }
        public string GeneroPersonaCargo { get; set; } = string.Empty;
        public string ParentescoPersonaCargo { get; set; } = string.Empty;
        public string CodigoMunicipioResidencia { get; set; } = string.Empty;
        public string AreaGeograficaResidencia { get; set; } = string.Empty;
        public string CondicionDiscapacidad { get; set; } = string.Empty;
        public string TipoCuota { get; set; } = string.Empty;
        public decimal ValorCuotaMonetaria { get; set; }
        public int NumeroCuotasPagadas { get; set; }
        public int NumPeriodosPagados { get; set; }
    }
}
