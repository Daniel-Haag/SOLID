namespace LSP1.Models.Bases;

/// <summary>
/// Dados e comportamento realmente comuns a qualquer conta.
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
}
