using System;

namespace ExportadorTxt.Domain.Entidades
{
    public class Contratos
    {
        public string Periodo_reportado { get; set; } = string.Empty;
        public string id_CCF { get; set; } = string.Empty;
        public string Nombre_CCF { get; set; } = string.Empty;
        public string NUMERO_CONTRATO_CONVENIO { get; set; } = string.Empty;
        public string id_Centro_Costo { get; set; } = string.Empty;
        public string Nombre_Centro { get; set; } = string.Empty;
        public string FECHA_FIRMA_CONTRATO { get; set; } = string.Empty;
        public string NUMERO_ACTA_CONSEJO_DIRECTIVO { get; set; } = string.Empty;
        public string NOMBRE_CONTRATANTE { get; set; } = string.Empty;
        public string CARGO_CONTRATANTE { get; set; } = string.Empty;
        public string NOMBRE_CONTRATISTA { get; set; } = string.Empty;
        public string IDENTIFICACION_CONTRATISTA { get; set; } = string.Empty;
        public string id_Naturaleza_Contrato { get; set; } = string.Empty;
        public string desc_Naturaleza_Contrato { get; set; } = string.Empty;
        public string id_Clase_Contrato { get; set; } = string.Empty;
        public string desc_Clase_Contrato { get; set; } = string.Empty;
        public string OBJETO_CONTRATO { get; set; } = string.Empty;
        public string FECHA_INICIO_CONTRATO { get; set; } = string.Empty;
        public string FECHA_FIN_CONTRATO { get; set; } = string.Empty;
        public string VALOR_INICIAL_CONTRATO { get; set; } = string.Empty;
        public string VALOR_ADICION1_CONTRATO { get; set; } = string.Empty;
        public string VALOR_APORTE_CCF { get; set; } = string.Empty;
        public string VALOR_APORTE_COOPERANTE { get; set; } = string.Empty;
        public string Tipo_Aporte_Cooperante { get; set; } = string.Empty;
        public string Tipo_Aporte_SSF { get; set; } = string.Empty;
        public string INTERVENTOR_SUPERVISOR_CONTRATO { get; set; } = string.Empty;
        public string CARGO_SUPERVISOR_INTERVENTOR { get; set; } = string.Empty;
        public string FECHA_ACTA_LIQUIDACION { get; set; } = string.Empty;
        public string PORCENTAJE_ANTICIPO { get; set; } = string.Empty;
        public string ANTICIPO_CONTRATO { get; set; } = string.Empty;
        public string ANTICIPO_LEGALIZADO { get; set; }
        public string Estado_Contrato { get; set; } = string.Empty;
    }
}