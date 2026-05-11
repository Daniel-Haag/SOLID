using OCP2.Enums;
using OCP2.Interfaces;
using OCP2.Models;
using System.Text;

namespace OCP2.Services;

public class ExportarRelatorioXmlService : IExportadorRelatorioService
{
    public FormatoExportacao Formato => FormatoExportacao.Xml;

    public ResultadoExportacao Exportar(RelatorioDeVendas relatorio)
    {
        var builder = new StringBuilder();
        builder.AppendLine("<RelatorioDeVendas>");
        builder.AppendLine($"  <Titulo>{relatorio.Titulo}</Titulo>");
        builder.AppendLine($"  <Periodo>{relatorio.Periodo}</Periodo>");
        builder.AppendLine($"  <Responsavel>{relatorio.Responsavel}</Responsavel>");
        builder.AppendLine($"  <QuantidadePedidos>{relatorio.QuantidadePedidos}</QuantidadePedidos>");
        builder.AppendLine($"  <TotalVendido>{relatorio.TotalVendido:F2}</TotalVendido>");
        builder.AppendLine("  <Itens>");

        foreach (var item in relatorio.Itens)
        {
            builder.AppendLine("    <ItemVendido>");
            builder.AppendLine($"      <Produto>{item.Produto}</Produto>");
            builder.AppendLine($"      <Quantidade>{item.Quantidade}</Quantidade>");
            builder.AppendLine($"      <ValorTotal>{item.ValorTotal:F2}</ValorTotal>");
            builder.AppendLine("    </ItemVendido>");
        }

        builder.AppendLine("  </Itens>");
        builder.AppendLine("</RelatorioDeVendas>");

        return new ResultadoExportacao
        {
            NomeArquivo = "relatorio-vendas.xml",
            Conteudo = builder.ToString()
        };
    }
}
