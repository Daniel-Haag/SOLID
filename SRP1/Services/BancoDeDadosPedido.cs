using SRP1.Models;
using System;

namespace SRP1.Services;

public class BancoDeDadosPedido
{
	public static void SalvarPedido(Pedido pedido)
	{
		Console.WriteLine($"Conectando ao banco de dados...");
		Console.WriteLine($"INSERT INTO Pedidos (Id, Cliente, Total) VALUES ({pedido.Id}, '{pedido.NomeCliente}', {pedido.Total})");
		foreach (var item in pedido.Itens)
		{
			Console.WriteLine($"INSERT INTO ItensPedido (PedidoId, Produto, Qtd, Preco) VALUES ({pedido.Id}, '{item.Produto}', {item.Quantidade}, {item.Preco})");
		}
		Console.WriteLine("Pedido salvo no banco de dados.");
    }
}
