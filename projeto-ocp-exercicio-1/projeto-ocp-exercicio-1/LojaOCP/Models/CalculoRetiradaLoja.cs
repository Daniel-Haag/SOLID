using LojaOCP.Interfaces;

namespace LojaOCP.Models;

public class CalculoRetiradaLoja : ICalculadoraFretePedido
{
    public ResultadoPedido CalcularFretePedido(ResultadoPedido resultadoPedido)
    {
        // Retirada em loja não paga frete;
        resultadoPedido.Frete = 0m;
        return resultadoPedido;
    }
}