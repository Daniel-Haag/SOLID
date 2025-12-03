namespace LojaOCP.Interfaces;

public interface ICalculadoraDescontoPedido
{
    ResultadoPedido CalcularValorFinal(Pedido pedido);
}