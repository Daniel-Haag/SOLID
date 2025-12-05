using LojaOCP.Interfaces;

namespace LojaOCP.Models;

public class CalculoFreteExpresso : ICalculadoraFretePedido
{
    public ResultadoPedido CalcularFretePedido(ResultadoPedido resultadoPedido)
    {
        // Frete expresso: 10 reais + 2 reais por km
        resultadoPedido.Frete = 10m + (resultadoPedido.DistanciaKm * 2m);
        return resultadoPedido;
    }
}