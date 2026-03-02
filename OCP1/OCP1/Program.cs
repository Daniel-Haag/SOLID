using OCP1.Enums;
using OCP1.Interfaces;
using OCP1.Models;
using OCP1.Services;
using System;

namespace OCP1;

internal class Program
{
    static void Main()
    {
        Console.WriteLine("==== Projeto OCP1 (violando OCP) ====");

        var calculadora = new CalculadoraFreteService();

        Testar(calculadora, new CalculaFreteNormalService(), TipoEntrega.Normal, 12);
        Testar(calculadora, new CalculaFreteExpressoService(), TipoEntrega.Expressa, 12);
        Testar(calculadora, new CalculaFreteRetiradaLojaService(), TipoEntrega.RetiradaLoja, 12);
        Testar(calculadora, new CalculaFreteAgendadoService(), TipoEntrega.Agendada, 12);

        Console.WriteLine("\nPressione qualquer tecla para sair.");
        Console.ReadKey();
    }

    static void Testar(CalculadoraFreteService calculadora, ICalculaFreteService calculaFreteService, TipoEntrega tipoEntrega, decimal km)
    {
        var pedido = new Pedido
        {
            Id = Guid.NewGuid(),
            DistanciaKm = km,
            ValorProdutos = 150m,
            TipoEntrega = tipoEntrega
        };

        var frete = calculadora.Calcular(pedido, calculaFreteService);

        Console.WriteLine($"Tipo: {pedido.TipoEntrega,-12} | Km: {km,5} | Frete: {frete,8:C}");
    }
}
