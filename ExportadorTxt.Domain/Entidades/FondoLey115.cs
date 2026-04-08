using System;

namespace ExportadorTxt.Domain.Entidades
{
    public class FondoLey115
    {
        public string WK_MES { get; set; } = string.Empty;
        public string id_CCF { get; set; } = string.Empty;
        public string Nombre_CCF { get; set; } = string.Empty;
        public string desc_Tipo_Documento { get; set; } = string.Empty;
        public string NUM_IDENTIFICACION { get; set; } = string.Empty;
        public string TIPO_DOCUMENTO_BENEFICIARIO { get; set; } = string.Empty;
        public string NUMERO_IDENTIFICACION_BENEFICIARIO { get; set; } = string.Empty;
        public string id_Colegio { get; set; } = string.Empty;
        public string Nombre_Colegio { get; set; } = string.Empty;
        public string desc_Grado_Escolaridad { get; set; } = string.Empty;
        public string TIPO_SUBSIDIO { get; set; } = string.Empty;
        public decimal VALOR_SUBSIDIO { get; set; }
        public string Codigo_Unico_Infraestructura { get; set; } = string.Empty;
        public string Nombre_Comercial_INFRAESTRUCTURA { get; set; } = string.Empty;
        public string desc_Categoria { get; set; } = string.Empty;
    }
}