using LSP1.Interfaces;
using LSP1.Models.Bases;

namespace LSP1.Services;

public class CaixaEletronicoService
{
    public string RealizarSaque<TConta>(TConta conta, decimal valor)
        where TConta : ContaBancaria, IContaBancariaSaque
    {
        var saqueRealizado = conta.Sacar(valor);

        if (!saqueRealizado)
        {
            return $"Saque nao realizado para {conta.Titular}. Saldo insuficiente.";
        }

        return $"Saque de {valor:C} realizado com sucesso para {conta.Titular}.";
    }
}
