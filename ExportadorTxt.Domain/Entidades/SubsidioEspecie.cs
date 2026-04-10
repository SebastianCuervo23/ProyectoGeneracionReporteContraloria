namespace ExportadorTxt.Domain.Entidades
{
    public class SubsidioEspecie

    {
        public string id_CCF { get; set; } = string.Empty;
        public string Tipo_Identificacion_Afiliado { get; set; } = string.Empty;
        public string NUM_IDENTIFICACION_AFILIADO { get; set; } = string.Empty;
        public string desc_Categoria { get; set; } = string.Empty;
        public string Tipo_Identificacion_Persona_a_Cargo { get; set; } = string.Empty;
        public string NUM_IDENTIFICACION_PERSONA_A_CARGO { get; set; } = string.Empty;
        public string Tipo_Subsidio { get; set; } = string.Empty;
        public decimal VAL_SUBSIDIO { get; set; }
    }
}
