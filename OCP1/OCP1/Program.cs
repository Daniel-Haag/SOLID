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

        Testar(calculadora, new CalculaFreteNormalService(), 12);
        Testar(calculadora, new CalculaFreteExpressoService(), 12);
        Testar(calculadora, new CalculaFreteRetiradaLojaService(), 12);
        Testar(calculadora, new CalculaFreteAgendadoService(), 12);

        Console.WriteLine("\nPressione qualquer tecla para sair.");
        Console.ReadKey();
    }

    static void Testar(CalculadoraFreteService calculadora, ICalculaFreteService calculaFreteService, decimal km)
    {
        var pedido = new Pedido
        {
            Id = Guid.NewGuid(),
            DistanciaKm = km,
            ValorProdutos = 150m
        };

        var frete = calculadora.Calcular(pedido, calculaFreteService);

        Console.WriteLine($"Tipo: {calculaFreteService.GetType().Name,-12} | Km: {km,5} | Frete: {frete,8:C}");
    }
}
