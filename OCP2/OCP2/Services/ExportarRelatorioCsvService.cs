using OCP2.Enums;
using OCP2.Interfaces;
using OCP2.Models;
using System.Text;

namespace OCP2.Services;

public class ExportarRelatorioCsvService : IExportadorRelatorioService
{
    public FormatoExportacao Formato => FormatoExportacao.Csv;

    public ResultadoExportacao Exportar(RelatorioDeVendas relatorio)
    {
        var builder = new StringBuilder();
        builder.AppendLine("Titulo;Periodo;Responsavel;QuantidadePedidos;TotalVendido");
        builder.AppendLine($"{relatorio.Titulo};{relatorio.Periodo};{relatorio.Responsavel};{relatorio.QuantidadePedidos};{relatorio.TotalVendido:F2}");
        builder.AppendLine();
        builder.AppendLine("Produto;Quantidade;ValorTotal");

        foreach (var item in relatorio.Itens)
        {
            builder.AppendLine($"{item.Produto};{item.Quantidade};{item.ValorTotal:F2}");
        }

        return new ResultadoExportacao
        {
            NomeArquivo = "relatorio-vendas.csv",
            Conteudo = builder.ToString()
        };
    }
}
