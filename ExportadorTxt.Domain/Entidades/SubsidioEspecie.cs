namespace ExportadorTxt.Domain.Entidades
{
    public class SubsidioEspecie


    {
        public string IdCCF { get; set; } = string.Empty;

        public string TipoIdentificacionAfiliado { get; set; } = string.Empty;

        public string NumeroIdentificacionAfiliado { get; set; } = string.Empty;

        public string Categoria { get; set; } = string.Empty;

        public string TipoIdentificacionPersonaCargo { get; set; } = string.Empty;

        public string NumeroIdentificacionPersonaCargo { get; set; } = string.Empty;

        public string TipoSubsidio { get; set; } = string.Empty;

        public string ValorSubsidio { get; set; } = string.Empty;
    }
}
