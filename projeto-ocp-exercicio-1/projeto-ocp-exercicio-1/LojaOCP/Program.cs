using System;
using LojaOCP.Enums;
using LojaOCP.Models;

namespace LojaOCP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==== Loja OCP (versão estragada) ====");
            
            var pedido1 = new Pedido
            {
                ClienteNome = "João Silva",
                TipoCliente = TipoCliente.Comum,
                ValorProdutos = 100m,
                TipoEntrega = TipoEntrega.Normal,
                DistanciaKm = 10
            };

            var pedido2 = new Pedido
            {
                ClienteNome = "Maria VIP",
                TipoCliente = TipoCliente.Vip,
                ValorProdutos = 250m,
                TipoEntrega = TipoEntrega.Expressa,
                DistanciaKm = 30
            };

            var pedido3 = new Pedido
            {
                ClienteNome = "Carlos Funcionário",
                TipoCliente = TipoCliente.Funcionario,
                ValorProdutos = 80m,
                TipoEntrega = TipoEntrega.RetiradaLoja,
                DistanciaKm = 5
            };

            ImprimirResumo(new CalculadoraPedido(new DescontoClienteComum(), new CalculoFreteNormal()), pedido1);
            ImprimirResumo(new CalculadoraPedido(new DescontoClienteVip()), pedido2);
            ImprimirResumo(new CalculadoraPedido(new DescontoClienteFuncionario()), pedido3);

            Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadKey();
        }

        static void ImprimirResumo(CalculadoraPedido calculadora, Pedido pedido)
        {
            Console.WriteLine("\n----------------------------");
            Console.WriteLine($"Cliente: {pedido.ClienteNome}");
            Console.WriteLine($"Tipo Cliente: {pedido.TipoCliente}");
            Console.WriteLine($"Entrega: {pedido.TipoEntrega}");
            Console.WriteLine($"Valor Produtos: {pedido.ValorProdutos:C}");

            var resultado = calculadora.CalcularValorFinal(pedido);

            Console.WriteLine($"Desconto aplicado: {resultado.Desconto:C}");
            Console.WriteLine($"Frete calculado: {resultado.Frete:C}");
            Console.WriteLine($"Valor final: {resultado.ValorFinal:C}");
        }
    }
}
