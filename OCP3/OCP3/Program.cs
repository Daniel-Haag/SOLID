using Microsoft.Extensions.DependencyInjection;
using OCP3.DI;
using OCP3.Enums;
using OCP3.Models;
using OCP3.Services;

namespace OCP3;

internal class Program
{
    static void Main()
    {
        var services = new ServiceCollection();
        services.AddProcessamentoPagamentos();

        using var serviceProvider = services.BuildServiceProvider();

        Console.WriteLine("==== Projeto OCP3 (respeitando OCP) ====");

        //Processador de pagamentos é resolvido via DI,
        //e o registro é feito automaticamente para todas
        //as implementações de IProcessadorPagamento
        var processador = serviceProvider.GetRequiredService<ProcessadorPagamentoService>();

        foreach (var pagamento in CriarPagamentosDeExemplo())
        {
            Testar(processador, pagamento);
        }

        Console.WriteLine("\nNovo formato? Crie uma nova classe que implemente IProcessadorPagamento.");
        Console.WriteLine("Se ela estiver na mesma assembly, o registro sera automatico.");

        if (!Console.IsInputRedirected)
        {
            Console.WriteLine("\nPressione qualquer tecla para sair.");
            Console.ReadKey();
        }
    }

    static void Testar(ProcessadorPagamentoService processador, Pagamento pagamento)
    {
        var resultado = processador.Processar(pagamento);

        Console.WriteLine($"\nForma: {pagamento.FormaPagamento}");
        Console.WriteLine($"Valor original: {pagamento.ValorOriginal:C}");
        Console.WriteLine($"Taxa: {resultado.ValorTaxa:C}");
        Console.WriteLine($"Valor final: {resultado.ValorFinal:C}");
        Console.WriteLine($"Mensagem: {resultado.Mensagem}");
    }

    static IEnumerable<Pagamento> CriarPagamentosDeExemplo()
    {
        yield return GeradorPagamentoService.CriarPagamento(FormaPagamento.Pix);
        yield return GeradorPagamentoService.CriarPagamento(FormaPagamento.CartaoCredito);
        yield return GeradorPagamentoService.CriarPagamento(FormaPagamento.Boleto);
        yield return GeradorPagamentoService.CriarPagamento(FormaPagamento.CarteiraDigital);
        yield return GeradorPagamentoService.CriarPagamento(FormaPagamento.CartaoDebito);
    }
}
