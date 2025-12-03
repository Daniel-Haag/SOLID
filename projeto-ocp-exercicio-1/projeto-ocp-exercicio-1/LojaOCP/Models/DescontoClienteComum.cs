using LojaOCP.Interfaces;

namespace LojaOCP.Models;

public class DescontoClienteComum : ICalculadoraDescontoPedido
{
    public ResultadoPedido CalcularValorFinal(Pedido pedido)
    {
        var resultado = new ResultadoPedido
        {
            ValorProdutos = pedido.ValorProdutos
        };
        
        if (pedido.ValorProdutos >= 100m)
        {
            resultado.Desconto = pedido.ValorProdutos * 0.05m;
        }
        
        return resultado;
    }
}