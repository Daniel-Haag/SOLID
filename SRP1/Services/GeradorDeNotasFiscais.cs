using SRP1.Models;
using System;

namespace SRP1.Services;

public class GeradorDeNotasFiscais
{
	public static void GerarNota(Pedido pedido)
	{
		Console.WriteLine("========== NOTA FISCAL ==========");
		Console.WriteLine($"Cliente: {pedido.NomeCliente}");
		Console.WriteLine($"Pedido #: {pedido.Id}");
		Console.WriteLine("---------------------------------");
		foreach (var item in pedido.Itens)
		{
			Console.WriteLine($"  {item.Produto} x{item.Quantidade} - {(item.Preco * item.Quantidade):C}");
		}
		Console.WriteLine("---------------------------------");
		Console.WriteLine($"TOTAL: {pedido.Total:C}");
		Console.WriteLine("==================================");
	}
}
