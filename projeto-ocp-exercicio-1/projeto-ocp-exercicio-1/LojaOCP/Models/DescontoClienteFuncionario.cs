using LojaOCP.Interfaces;

namespace LojaOCP.Models;

public class DescontoClienteFuncionario : ICalculadoraDescontoPedido
{
    public ResultadoPedido CalcularValorFinal(Pedido pedido)
    {
        var resultado = new ResultadoPedido
        {
            ValorProdutos = pedido.ValorProdutos
        };
        
        var descontoBruto = pedido.ValorProdutos * 0.20m;
        resultado.Desconto = Math.Min(descontoBruto, 50m);
        
        return resultado;
    }
}