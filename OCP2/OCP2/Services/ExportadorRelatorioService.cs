using OCP2.Enums;
using OCP2.Interfaces;
using OCP2.Models;

namespace OCP2.Services;

public class ExportadorRelatorioService
{
    private readonly IReadOnlyDictionary<FormatoExportacao, IExportadorRelatorioService> _exportadores;

    public ExportadorRelatorioService(IEnumerable<IExportadorRelatorioService> exportadores)
    {
        ArgumentNullException.ThrowIfNull(exportadores);
        _exportadores = exportadores.ToDictionary(exportador => exportador.Formato);
    }

    public ResultadoExportacao Exportar(RelatorioDeVendas relatorio, FormatoExportacao formato)
    {
        ArgumentNullException.ThrowIfNull(relatorio);

        if (!_exportadores.TryGetValue(formato, out var exportador))
        {
            throw new NotSupportedException($"Formato {formato} nao suportado.");
        }

        return exportador.Exportar(relatorio);
    }
}
