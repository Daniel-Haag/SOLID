namespace LojaOCP.Interfaces;

public interface ICalculadoraFretePedido
{
    ResultadoPedido CalcularFretePedido(ResultadoPedido resultadoPedido, Pedido pedido);
}