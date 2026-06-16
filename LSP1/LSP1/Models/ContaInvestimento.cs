namespace LSP1.Models;

/// <summary>
/// Violacao de LSP: herda um contrato de saque que esta classe nao consegue cumprir.
/// </summary>
public class ContaInvestimento : ContaBancaria
{
    public ContaInvestimento(string titular, decimal saldoInicial) : base(titular, saldoInicial)
    {
    }

    public override bool Sacar(decimal valor)
    {
        throw new NotSupportedException("Conta investimento nao permite saque imediato pelo caixa eletronico.");
    }
}
