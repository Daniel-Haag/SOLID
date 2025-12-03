using LojaOCP.Interfaces;

namespace LojaOCP.Models;

public class CalculoFreteNormal : ICalculadoraFretePedido
{
    public ResultadoPedido CalcularFretePedido(ResultadoPedido resultadoPedido)
    {
        // Frete normal: 5 reais + 1 real por km
        resultadoPedido.Frete = 5m + (resultadoPedido.DistanciaKm * 1m);
        return resultadoPedido;
    }
}