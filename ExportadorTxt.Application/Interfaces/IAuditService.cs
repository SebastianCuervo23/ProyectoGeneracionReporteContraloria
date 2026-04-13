namespace ExportadorTxt.Application.Interfaces
{
    public interface IAuditService
    {
        Task RegistrarArchivoAsync(AuditRecord registro);
        Task RegistrarErrorAsync(ErrorRecord error);
    }
    public record ErrorRecord(
    string? TipoReporte,
    int? AnioMes,
    string? NombreArchivo,
    string MensajeError,
    string? StackTrace,
    string? TipoExcepcion,
    int? PaginaFallo = null
);
    public record AuditRecord(
    string NombreArchivo,
    string TipoReporte,
    string RutaCompleta,
    int AnioMes,
    long TotalRegistros,
    int TotalPaginas,
    long TamanoArchivoBytes,
    DateTime FechaInicio,
    DateTime FechaFin
);
}
