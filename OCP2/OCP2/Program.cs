using OCP2.Enums;
using OCP2.Interfaces;
using OCP2.Models;
using OCP2.Services;

namespace OCP2;

internal class Program
{
    static void Main()
    {
        Console.WriteLine("==== Projeto OCP2 (respeitando OCP) ====");

        var relatorio = CriarRelatorio();
        var exportador = CriarExportadorPrincipal();

        Testar(exportador, relatorio, FormatoExportacao.Csv);
        Testar(exportador, relatorio, FormatoExportacao.Json);
        Testar(exportador, relatorio, FormatoExportacao.Xml);
        Testar(exportador, relatorio, FormatoExportacao.Html);

        Console.WriteLine("\nNovo formato? Crie uma nova classe de exportacao e registre-a na composicao principal.");

        if (!Console.IsInputRedirected)
        {
            Console.WriteLine("\nPressione qualquer tecla para sair.");
            Console.ReadKey();
        }
    }

    static ExportadorRelatorioService CriarExportadorPrincipal()
    {
        IExportadorRelatorioService[] exportadores =
        [
            new ExportarRelatorioCsvService(),
            new ExportarRelatorioJsonService(),
            new ExportarRelatorioXmlService(),
            new ExportarRelatorioHtmlService()
        ];

        return new ExportadorRelatorioService(exportadores);
    }

    static void Testar(ExportadorRelatorioService exportador, RelatorioDeVendas relatorio, FormatoExportacao formato)
    {
        var resultado = exportador.Exportar(relatorio, formato);

        Console.WriteLine($"\nFormato: {formato}");
        Console.WriteLine($"Arquivo: {resultado.NomeArquivo}");
        Console.WriteLine(resultado.Conteudo);
    }

    static RelatorioDeVendas CriarRelatorio()
    {
        return new RelatorioDeVendas
        {
            Titulo = "Resumo de vendas",
            Periodo = "Maio/2026",
            Responsavel = "Equipe comercial",
            TotalVendido = 12450.75m,
            QuantidadePedidos = 38,
            Itens =
            {
                new ItemVendido
                {
                    Produto = "Notebook",
                    Quantidade = 3,
                    ValorTotal = 10500.00m
                },
                new ItemVendido
                {
                    Produto = "Mouse gamer",
                    Quantidade = 5,
                    ValorTotal = 975.75m
                },
                new ItemVendido
                {
                    Produto = "Teclado mecanico",
                    Quantidade = 4,
                    ValorTotal = 975.00m
                }
            }
        };
    }
}
