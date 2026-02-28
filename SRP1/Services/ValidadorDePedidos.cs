using SRP1.Models;
using System;

namespace SRP1.Services;

public class ValidadorDePedidos
{
    public static void Validar(Pedido pedido)
    {
        if (string.IsNullOrWhiteSpace(pedido.NomeCliente))
            throw new ArgumentException("Nome do cliente é obrigatório.");
        if (string.IsNullOrWhiteSpace(pedido.EmailCliente) || !pedido.EmailCliente.Contains('@'))
            throw new ArgumentException("E-mail do cliente é inválido.");
        if (pedido.Itens.Count == 0)
            throw new ArgumentException("O pedido deve conter ao menos um item.");
        foreach (var item in pedido.Itens)
        {
            if (item.Quantidade <= 0)
                throw new ArgumentException($"Quantidade inválida para o produto '{item.Produto}'.");
            if (item.Preco <= 0)
                throw new ArgumentException($"Preço inválido para o produto '{item.Produto}'.");
        }

        Console.WriteLine("Pedido validado com sucesso.");
    }
}
