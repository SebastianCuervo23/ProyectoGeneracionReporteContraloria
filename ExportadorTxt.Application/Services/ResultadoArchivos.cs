public class ResultadoArchivos
{
    private readonly List<string> _archivos = new();

    public void Agregar(string nombreArchivo, string totalRegistros, string tamanoArchivoBytes)
    {
        _archivos.Add($"{nombreArchivo} - {totalRegistros} registros - {tamanoArchivoBytes} GB");
    }

    public IReadOnlyList<string> ObtenerTodos()
    {
        return _archivos;
    }
}