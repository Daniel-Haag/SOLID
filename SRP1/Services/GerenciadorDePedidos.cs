using SRP1.Models;
using SRP1.Services;

namespace SRP1.Services;

public class GerenciadorDePedidos
{
    public void ProcessarPedido(Pedido pedido)
    {
        ValidadorDePedidos.Validar(pedido);

        BancoDeDadosPedido.SalvarPedido(pedido);

        NotificacaoEmailPedido.EnviarEmail(pedido);

        GeradorDeNotasFiscais.GerarNota(pedido);
    }
}
