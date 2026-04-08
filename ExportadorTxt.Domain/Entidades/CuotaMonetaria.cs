public class CuotaMonetaria
{
    public string Fecha_Reporte { get; set; } = string.Empty;
    public string id_CCF { get; set; } = string.Empty;
    public string Nombre_CCF { get; set; } = string.Empty;
    public string Tipo_Documento_Empresa { get; set; } = string.Empty;
    public string Num_Documento_Empresa { get; set; } = string.Empty;
    public string Tipo_Documento_Afiliado { get; set; } = string.Empty;
    public string Num_Documento_Afiliado { get; set; } = string.Empty;
    public string Tipo_Documento_Persona_Cargo { get; set; } = string.Empty;
    public string Num_Documento_Persona_Cargo { get; set; } = string.Empty;
    public string Primer_Nombre_Persona_Cargo { get; set; } = string.Empty;
    public string Segundo_Nombre_Persona_Cargo { get; set; } = string.Empty;
    public string Primer_Apellido_Persona_Cargo { get; set; } = string.Empty;
    public string Segundo_Apellido_Persona_Cargo { get; set; } = string.Empty;
    public string Fecha_Nacimiento_Persona_a_Cargo { get; set; } = string.Empty;
    public string Genero_Persona_a_Cargo { get; set; } = string.Empty;
    public string Parentesco_Persona_a_Cargo { get; set; } = string.Empty;
    public string Codigo_Municipio_Residencia { get; set; } = string.Empty;
    public string Area_Geografica_Residencia_Persona_Cargo { get; set; } = string.Empty;
    public string Condicion_Discapacidad { get; set; } = string.Empty;
    public string desc_Tipo_Cuota { get; set; } = string.Empty;
    public string Valor_Cuota_Monetaria { get; set; } = string.Empty;
    public int Numero_Cuotas_Pagadas { get; set; }
    public int Num_Periodos_Pagados { get; set; }
}