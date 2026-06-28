using LSP1.Interfaces;
using LSP1.Models.Bases;

namespace LSP1.Models.Derivadas;

public class ContaCorrente : ContaBancaria, IContaBancariaSaque, IContaBancariaDeposito
{
    public ContaCorrente(string titular, decimal saldoInicial) : base(titular, saldoInicial)
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

    public bool Sacar(decimal valor)
    {
        if (valor <= 0)
        {
            throw new ArgumentException("O valor do saque deve ser maior que zero.");
        }

        if (Saldo < valor)
        {
            return false;
        }

        Saldo -= valor;
        return true;
    }
}
