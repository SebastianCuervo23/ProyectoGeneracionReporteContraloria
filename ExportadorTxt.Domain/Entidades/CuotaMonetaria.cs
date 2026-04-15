public class CuotaMonetaria
{
    public string FechaReporte { get; set; } = string.Empty;
    public string IdCcf { get; set; } = string.Empty;
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
    public string FechaNacimientoPersonaCargo { get; set; } = string.Empty;
    public string GeneroPersonaCargo { get; set; } = string.Empty;
    public string ParentescoPersonaCargo { get; set; } = string.Empty;
    public string CodigoMunicipioResidencia { get; set; } = string.Empty;
    public string AreaGeograficaResidencia { get; set; } = string.Empty;
    public string Condicion_Discapacidad { get; set; } = string.Empty;
    public string TipoCuota { get; set; } = string.Empty;
    public string ValorCuotaMonetaria { get; set; } = string.Empty;
    public int NumeroCuotasPagadas { get; set; }
    public int NumPeriodosPagados { get; set; }
}