using LSP1.Interfaces;
using LSP1.Models.Bases;
using LSP1.Models.Derivadas;
using LSP1.Services;

namespace LSP1;

internal class Program
{
    static void Main()
    {
        Console.WriteLine("==== Projeto LSP1 (respeitando LSP) ====");

        var caixaEletronico = new CaixaEletronicoService();

        var contaCorrente = new ContaCorrente("Ana", 1000m);
        var contaInvestimento = new ContaInvestimento("Bruno", 1000m);

        Testar(caixaEletronico, contaCorrente, 200m);
        ExibirContaSemSaque(contaInvestimento);

        Console.WriteLine("\nMissao cumprida: cada tipo de conta implementa apenas os contratos que consegue cumprir.");

        if (!Console.IsInputRedirected)
        {
            Console.WriteLine("\nPressione qualquer tecla para sair.");
            Console.ReadKey();
        }
    }

    static void Testar<TConta>(CaixaEletronicoService caixaEletronico, TConta conta, decimal valor)
        where TConta : ContaBancaria, IContaBancariaSaque
    {
        Console.WriteLine($"\nConta: {conta.GetType().Name} | Titular: {conta.Titular} | Saldo inicial: {conta.Saldo:C}");
        var mensagem = caixaEletronico.RealizarSaque(conta, valor);
        Console.WriteLine(mensagem);
        Console.WriteLine($"Saldo final: {conta.Saldo:C}");
    }

    static void ExibirContaSemSaque(ContaBancaria conta)
    {
        Console.WriteLine($"\nConta: {conta.GetType().Name} | Titular: {conta.Titular} | Saldo inicial: {conta.Saldo:C}");
        Console.WriteLine("Esta conta nao participa do fluxo de saque do caixa eletronico.");
    }
}
