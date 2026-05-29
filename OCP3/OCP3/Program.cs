using OCP3.Enums;
using OCP3.Models;
using OCP3.Services;

namespace OCP3;

internal class Program
{
    static void Main()
    {
        Console.WriteLine("==== Projeto OCP3 (violando OCP) ====");

        var processador = new ProcessadorPagamentoService();

        Testar(processador, CriarPagamentoPix());
        Testar(processador, CriarPagamentoCartaoCredito());
        Testar(processador, CriarPagamentoBoleto());
        Testar(processador, CriarPagamentoCarteiraDigital());

        Console.WriteLine("\nSua missao: adicionar uma nova forma de pagamento sem modificar a classe ProcessadorPagamentoService.");

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

    static Pagamento CriarPagamentoPix()
    {
        return new Pagamento
        {
            Id = Guid.NewGuid(),
            Cliente = "Ana",
            ValorOriginal = 250.00m,
            FormaPagamento = FormaPagamento.Pix,
            Parcelas = 1
        };
    }

    static Pagamento CriarPagamentoCartaoCredito()
    {
        return new Pagamento
        {
            Id = Guid.NewGuid(),
            Cliente = "Bruno",
            ValorOriginal = 820.50m,
            FormaPagamento = FormaPagamento.CartaoCredito,
            Parcelas = 6
        };
    }

    static Pagamento CriarPagamentoBoleto()
    {
        return new Pagamento
        {
            Id = Guid.NewGuid(),
            Cliente = "Carla",
            ValorOriginal = 415.90m,
            FormaPagamento = FormaPagamento.Boleto,
            Parcelas = 1
        };
    }

    static Pagamento CriarPagamentoCarteiraDigital()
    {
        return new Pagamento
        {
            Id = Guid.NewGuid(),
            Cliente = "Diego",
            ValorOriginal = 99.90m,
            FormaPagamento = FormaPagamento.CarteiraDigital,
            Parcelas = 1
        };
    }
}
