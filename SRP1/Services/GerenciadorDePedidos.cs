using SRP1.Models;

namespace SRP1.Services;

public class GerenciadorDePedidos
{
    public void ProcessarPedido(Pedido pedido)
    {
        // --- Validação ---
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

        // --- Persistência ---
        Console.WriteLine($"Conectando ao banco de dados...");
        Console.WriteLine($"INSERT INTO Pedidos (Id, Cliente, Total) VALUES ({pedido.Id}, '{pedido.NomeCliente}', {pedido.Total})");
        foreach (var item in pedido.Itens)
        {
            Console.WriteLine($"INSERT INTO ItensPedido (PedidoId, Produto, Qtd, Preco) VALUES ({pedido.Id}, '{item.Produto}', {item.Quantidade}, {item.Preco})");
        }
        Console.WriteLine("Pedido salvo no banco de dados.");

        // --- Notificação por e-mail ---
        Console.WriteLine($"Conectando ao servidor SMTP...");
        Console.WriteLine($"De: loja@exemplo.com");
        Console.WriteLine($"Para: {pedido.EmailCliente}");
        Console.WriteLine($"Assunto: Confirmação do Pedido #{pedido.Id}");
        Console.WriteLine($"Corpo: Olá {pedido.NomeCliente}, seu pedido no valor de {pedido.Total:C} foi confirmado!");
        Console.WriteLine("E-mail enviado com sucesso.");

        // --- Geração de nota fiscal ---
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
