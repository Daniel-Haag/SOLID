using System.Text;
using System.Text.Json;
using OCP2.Enums;
using OCP2.Models;

namespace OCP2.Services;

/// <summary>
/// Classe propositalmente fechada para extensao da forma errada.
/// Sempre que um novo formato for criado, este metodo precisara ser modificado.
/// </summary>
public class ExportadorRelatorioService
{
    public ResultadoExportacao Exportar(RelatorioDeVendas relatorio, FormatoExportacao formato)
    {
        switch (formato)
        {
            case FormatoExportacao.Csv:
                return new ResultadoExportacao
                {
                    NomeArquivo = "relatorio-vendas.csv",
                    Conteudo = GerarCsv(relatorio)
                };

            case FormatoExportacao.Json:
                return new ResultadoExportacao
                {
                    NomeArquivo = "relatorio-vendas.json",
                    Conteudo = JsonSerializer.Serialize(relatorio, new JsonSerializerOptions
                    {
                        WriteIndented = true
                    })
                };

            case FormatoExportacao.Xml:
                return new ResultadoExportacao
                {
                    NomeArquivo = "relatorio-vendas.xml",
                    Conteudo = GerarXml(relatorio)
                };

            case FormatoExportacao.Html:
                return new ResultadoExportacao
                {
                    NomeArquivo = "relatorio-vendas.html",
                    Conteudo = GerarHtml(relatorio)
                };

            default:
                throw new NotSupportedException($"Formato {formato} nao suportado.");
        }
    }

    private static string GerarCsv(RelatorioDeVendas relatorio)
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

        return builder.ToString();
    }

    private static string GerarXml(RelatorioDeVendas relatorio)
    {
        var builder = new StringBuilder();

        builder.AppendLine("<relatorio>");
        builder.AppendLine($"  <titulo>{relatorio.Titulo}</titulo>");
        builder.AppendLine($"  <periodo>{relatorio.Periodo}</periodo>");
        builder.AppendLine($"  <responsavel>{relatorio.Responsavel}</responsavel>");
        builder.AppendLine($"  <quantidadePedidos>{relatorio.QuantidadePedidos}</quantidadePedidos>");
        builder.AppendLine($"  <totalVendido>{relatorio.TotalVendido:F2}</totalVendido>");
        builder.AppendLine("  <itens>");

        foreach (var item in relatorio.Itens)
        {
            builder.AppendLine("    <item>");
            builder.AppendLine($"      <produto>{item.Produto}</produto>");
            builder.AppendLine($"      <quantidade>{item.Quantidade}</quantidade>");
            builder.AppendLine($"      <valorTotal>{item.ValorTotal:F2}</valorTotal>");
            builder.AppendLine("    </item>");
        }

        builder.AppendLine("  </itens>");
        builder.AppendLine("</relatorio>");

        return builder.ToString();
    }

    private static string GerarHtml(RelatorioDeVendas relatorio)
    {
        var builder = new StringBuilder();

        builder.AppendLine("<html>");
        builder.AppendLine("<body>");
        builder.AppendLine($"  <h1>{relatorio.Titulo}</h1>");
        builder.AppendLine($"  <p>Periodo: {relatorio.Periodo}</p>");
        builder.AppendLine($"  <p>Responsavel: {relatorio.Responsavel}</p>");
        builder.AppendLine($"  <p>Pedidos: {relatorio.QuantidadePedidos}</p>");
        builder.AppendLine($"  <p>Total vendido: R$ {relatorio.TotalVendido:F2}</p>");
        builder.AppendLine("  <ul>");

        foreach (var item in relatorio.Itens)
        {
            builder.AppendLine($"    <li>{item.Produto} - {item.Quantidade} unidade(s) - R$ {item.ValorTotal:F2}</li>");
        }

        builder.AppendLine("  </ul>");
        builder.AppendLine("</body>");
        builder.AppendLine("</html>");

        return builder.ToString();
    }
}
