using LojaOCP.Interfaces;

namespace LojaOCP.Models;

public class DescontoClienteVip : ICalculadoraDescontoPedido
{
    public ResultadoPedido CalcularValorFinal(Pedido pedido)
    {
        var resultado = new ResultadoPedido
        {
            ValorProdutos = pedido.ValorProdutos
        };
        
        resultado.Desconto = pedido.ValorProdutos * 0.10m;
        
        return resultado;
    }
}