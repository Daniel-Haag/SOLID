using SRP1.Models;
using System;

namespace SRP1.Services;

public class NotificacaoEmailPedido
{
    public static void EnviarEmail(Pedido pedido)
    {
        Console.WriteLine($"Conectando ao servidor SMTP...");
        Console.WriteLine($"De: loja@exemplo.com");
        Console.WriteLine($"Para: {pedido.EmailCliente}");
        Console.WriteLine($"Assunto: Confirmação do Pedido #{pedido.Id}");
        Console.WriteLine($"Corpo: Olá {pedido.NomeCliente}, seu pedido no valor de {pedido.Total:C} foi confirmado!");
        Console.WriteLine("E-mail enviado com sucesso.");
    }
}