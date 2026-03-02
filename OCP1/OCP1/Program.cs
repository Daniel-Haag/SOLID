using System;

namespace OCP1;

internal class Program
{
    static void Main()
    {
        Console.WriteLine("==== Projeto OCP1 (violando OCP) ====");

        var calculadora = new CalculadoraFrete();

        Testar(calculadora, TipoEntrega.Normal, 12);
        Testar(calculadora, TipoEntrega.Expressa, 12);
        Testar(calculadora, TipoEntrega.RetiradaLoja, 12);
        Testar(calculadora, TipoEntrega.Agendada, 12);

        Console.WriteLine("\nDica: amanhã pode surgir TipoEntrega.Drone. Idealmente você NÃO deveria mexer na CalculadoraFrete...");
        Console.WriteLine("\nPressione qualquer tecla para sair.");
        Console.ReadKey();
    }

    static void Testar(CalculadoraFrete calculadora, TipoEntrega tipo, decimal km)
    {
        var pedido = new Pedido
        {
            Id = Guid.NewGuid(),
            TipoEntrega = tipo,
            DistanciaKm = km,
            ValorProdutos = 150m
        };

        var frete = calculadora.Calcular(pedido);

        Console.WriteLine($"Tipo: {tipo,-12} | Km: {km,5} | Frete: {frete,8:C}");
    }
}
