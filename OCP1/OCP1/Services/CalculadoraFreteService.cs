using OCP1.Enums;
using OCP1.Interfaces;
using OCP1.Models;
using System;

namespace OCP1.Services;

/// <summary>
/// Corrigindo violação do OCP - Open/Closed Principle
/// - Separa o comportamento extensível por trás de uma interface e inverte as dependências.
/// - Sempre que surgir um novo TipoEntrega, ele deve ser extendido como uma nova classe.
/// - Não é mais necessário modificar este método.
/// </summary>
public class CalculadoraFreteService
{
    public decimal Calcular(Pedido pedido, ICalculaFreteService calculaFrete)
    {
        return calculaFrete.Calcular(pedido);
    }
}
