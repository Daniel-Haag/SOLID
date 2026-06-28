using LSP1.Interfaces;
using LSP1.Models.Bases;

namespace LSP1.Models.Derivadas;

/// <summary>
/// Conta que aceita deposito, mas nao participa do fluxo de saque imediato.
/// </summary>
public class ContaInvestimento : ContaBancaria, IContaBancariaDeposito
{
    public ContaInvestimento(string titular, decimal saldoInicial) : base(titular, saldoInicial)
    {
    }

    public void Depositar(decimal valor)
    {
        if (valor <= 0)
        {
            throw new ArgumentException("O valor do deposito deve ser maior que zero.");
        }

        Saldo += valor;
    }
}
