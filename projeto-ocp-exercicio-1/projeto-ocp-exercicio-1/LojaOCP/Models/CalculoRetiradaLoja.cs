using LojaOCP.Interfaces;

namespace LojaOCP.Models;

public class CalculoRetiradaLoja : ICalculadoraFretePedido
{
    public ResultadoPedido CalcularFretePedido(ResultadoPedido resultadoPedido, Pedido pedido = null)
    {
        // Retirada em loja não paga frete;
        resultadoPedido.Frete = 0m;
        return resultadoPedido;
    }
}