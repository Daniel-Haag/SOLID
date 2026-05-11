using OCP2.Enums;
using OCP2.Interfaces;
using OCP2.Models;
using System.Text.Json;

namespace OCP2.Services;

public class ExportarRelatorioJsonService : IExportadorRelatorioService
{
    public FormatoExportacao Formato => FormatoExportacao.Json;

    public ResultadoExportacao Exportar(RelatorioDeVendas relatorio)
    {
        var json = JsonSerializer.Serialize(relatorio, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        return new ResultadoExportacao
        {
            NomeArquivo = "relatorio-vendas.json",
            Conteudo = json
        };
    }
}
