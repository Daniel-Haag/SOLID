using LSP1.Models;
using LSP1.Services;

namespace LSP1;

internal class Program
{
    static void Main()
    {
        Console.WriteLine("==== Projeto LSP1 (violando LSP) ====");

        var caixaEletronico = new CaixaEletronicoService();

        var contaCorrente = new ContaCorrente("Ana", 1000m);
        var contaInvestimento = new ContaInvestimento("Bruno", 1000m);

        Testar(caixaEletronico, contaCorrente, 200m);
        Testar(caixaEletronico, contaInvestimento, 200m);

        Console.WriteLine("\nSua missao: refatorar a hierarquia para que a substituicao nao quebre o fluxo do caixa eletronico.");

        if (!Console.IsInputRedirected)
        {
            Console.WriteLine("\nPressione qualquer tecla para sair.");
            Console.ReadKey();
        }
    }

    static void Testar(CaixaEletronicoService caixaEletronico, ContaBancaria conta, decimal valor)
    {
        Console.WriteLine($"\nConta: {conta.GetType().Name} | Titular: {conta.Titular} | Saldo inicial: {conta.Saldo:C}");

        try
        {
            var mensagem = caixaEletronico.RealizarSaque(conta, valor);
            Console.WriteLine(mensagem);
            Console.WriteLine($"Saldo final: {conta.Saldo:C}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Falha inesperada: {ex.Message}");
            Console.WriteLine("A classe filha nao conseguiu substituir a classe base sem quebrar o comportamento esperado.");
        }
    }
}
