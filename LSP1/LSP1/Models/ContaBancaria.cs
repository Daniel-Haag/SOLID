namespace LSP1.Models;

/// <summary>
/// Contrato implicito: toda conta bancaria pode sacar se houver saldo suficiente.
/// </summary>
public abstract class ContaBancaria
{
    protected ContaBancaria(string titular, decimal saldoInicial)
    {
        Titular = titular;
        Saldo = saldoInicial;
    }

    public string Titular { get; }
    public decimal Saldo { get; protected set; }

    public virtual void Depositar(decimal valor)
    {
        if (valor <= 0)
        {
            throw new ArgumentException("O valor do deposito deve ser maior que zero.");
        }

        Saldo += valor;
    }

    public virtual bool Sacar(decimal valor)
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
