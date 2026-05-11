using OCP2.Enums;
using OCP2.Interfaces;
using OCP2.Models;
using System.Text;

namespace OCP2.Services;

public class ExportarRelatorioHtmlService : IExportadorRelatorioService
{
    public FormatoExportacao Formato => FormatoExportacao.Html;

    public ResultadoExportacao Exportar(RelatorioDeVendas relatorio)
    {
        var builder = new StringBuilder();
        builder.AppendLine("<html>");
        builder.AppendLine("<head><title>Relatorio de Vendas</title></head>");
        builder.AppendLine("<body>");
        builder.AppendLine($"<h1>{relatorio.Titulo}</h1>");
        builder.AppendLine($"<p>Periodo: {relatorio.Periodo}</p>");
        builder.AppendLine($"<p>Responsavel: {relatorio.Responsavel}</p>");
        builder.AppendLine($"<p>Quantidade de Pedidos: {relatorio.QuantidadePedidos}</p>");
        builder.AppendLine($"<p>Total Vendido: {relatorio.TotalVendido:F2}</p>");
        builder.AppendLine("<h2>Itens Vendidos</h2>");
        builder.AppendLine("<table border='1'>");
        builder.AppendLine("<tr><th>Produto</th><th>Quantidade</th><th>Valor Total</th></tr>");

        foreach (var item in relatorio.Itens)
        {
            builder.AppendLine($"<tr><td>{item.Produto}</td><td>{item.Quantidade}</td><td>{item.ValorTotal:F2}</td></tr>");
        }

        builder.AppendLine("</table>");
        builder.AppendLine("</body>");
        builder.AppendLine("</html>");

        return new ResultadoExportacao
        {
            NomeArquivo = "relatorio-vendas.html",
            Conteudo = builder.ToString()
        };
    }
}
