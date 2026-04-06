using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportadorTxt.Domain.Entidades
{
    public class Afiliados
    {
        public string IdCcf { get; set; } = string.Empty;
        public string NombreCcf { get; set; } = string.Empty;
        public string TipoDocumentoEmpresa { get; set; } = string.Empty;
        public string NumeroDocumentoEmpresa { get; set; } = string.Empty;
        public string TipoDocumentoAfiliado { get; set; } = string.Empty;
        public string NumeroDocumentoAfiliado { get; set; } = string.Empty;
        public string PrimerNombre { get; set; } = string.Empty;
        public string SegundoNombre { get; set; } = string.Empty;
        public string PrimerApellido { get; set; } = string.Empty;
        public string SegundoApellido { get; set; } = string.Empty;
        public DateTime? FechaNacimiento { get; set; }
        public string Genero { get; set; } = string.Empty;
        public string GradoEscolaridad { get; set; } = string.Empty;
        public string CodigoOcupacionCiou { get; set; } = string.Empty;
        public string OcupacionCiou { get; set; } = string.Empty;
        public string FactorVulnerabilidad { get; set; } = string.Empty;
        public string EstadoCivil { get; set; } = string.Empty;
        public string PertenenciaEtnica { get; set; } = string.Empty;
        public string PaisResidencia { get; set; } = string.Empty;
        public string CiudadAfiliado { get; set; } = string.Empty;
        public string AreaGeograficaResidencia { get; set; } = string.Empty;
        public string AreaGeograficaLabor { get; set; } = string.Empty;
        public string CodigoMunicipioLabor { get; set; } = string.Empty;
        public decimal? SalarioBasico { get; set; }
        public string TipoAfiliado { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public bool EsBeneficiarioSubsidioDinero { get; set; }
    }
}
