using System;
using CursoFoop_Solid_Exercicio2.Interfaces;

namespace CursoFoop_Solid_Exercicio2
{
    class Program
    {
        /// <summary>
        /// O exercício pede para implementar o registro de log em arquivo texto além do console.
        /// Mantive a classe Pedido fechada para modificação, mas aberta para extensão através da interface ILogger.
        /// Assim, podemos adicionar novos tipos de loggers (como TxtLogger) sem alterar a classe Pedido.
        /// Neste exercício eu apliquei OCP e DIP.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //Criação dos loggers
           ILogger consoleLogger = new ConsoleLogger();
           ILogger txtLogger = new TxtLogger();
           
           //O exercício pede para que eu indique quais princípios podem ser aplicados para desacoplar o código e
           //torná-lo mais robusto.
           
           //Para isso preciso saber explicar cada um dos princípios SOLID
           //S - Single Responsibility Principle (Princípio da Responsabilidade Única)
           //O código da classe Pedido tem mais de uma responsabilidade: gerenciar pedidos e registrar logs.
           //Para aplicar o SRP, podemos separar a funcionalidade de logging em uma classe distinta.
           
           //O - Open/Closed Principle (Princípio Aberto/Fechado)
           //A classe Pedido está fechada para modificação, mas aberta para extensão.
           //Podemos criar subclasses de Pedido para adicionar funcionalidades específicas sem alterar a classe base.
           
           //L - Liskov Substitution Principle (Princípio da Substituição de Liskov)
           //As subclasses de Pedido devem poder substituir a classe base sem alterar o comportamento esperado.
           
           //I - Interface Segregation Principle (Princípio da Segregação de Interfaces)
           //Se tivermos interfaces para pedidos, elas devem ser específicas para as necessidades dos clientes,
           //evitando interfaces genéricas que forcem a implementação de métodos desnecessários.
           
           //D - Dependency Inversion Principle (Princípio da Inversão de Dependência)
           //A classe Pedido depende diretamente de ConsoleLogger.
           //Para aplicar o DIP, podemos depender de uma abstração (interface ILogger) em vez de uma implementação concreta.

            Console.WriteLine("Tecle enter para iniciar...");
            Pedido pedido = new Pedido(consoleLogger);
            
            pedido.AdicionarPedido();
            Console.ReadLine();
        }
    }
}
