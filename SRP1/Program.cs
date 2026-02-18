using SRP1.Models;
using SRP1.Services;

var pedido = new Pedido
{
    Id = 1,
    NomeCliente = "João Silva",
    EmailCliente = "joao@email.com",
    Itens =
    [
        new ItemPedido { Produto = "Teclado Mecânico", Quantidade = 1, Preco = 350.00m },
        new ItemPedido { Produto = "Mouse Gamer",      Quantidade = 2, Preco = 150.00m },
        new ItemPedido { Produto = "Monitor 27\"",     Quantidade = 1, Preco = 1800.00m }
    ]
};

var gerenciador = new GerenciadorDePedidos();

try
{
    gerenciador.ProcessarPedido(pedido);
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Erro: {ex.Message}");
}
