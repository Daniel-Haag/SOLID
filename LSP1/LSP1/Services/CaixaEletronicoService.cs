using LSP1.Models;

namespace LSP1.Services;

public class CaixaEletronicoService
{
    public string RealizarSaque(ContaBancaria conta, decimal valor)
    {
        var saqueRealizado = conta.Sacar(valor);

        if (!saqueRealizado)
        {
            return $"Saque nao realizado para {conta.Titular}. Saldo insuficiente.";
        }

        return $"Saque de {valor:C} realizado com sucesso para {conta.Titular}.";
    }
}
