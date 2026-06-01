using OCP3.Enums;
using OCP3.Models;

namespace OCP3.Services
{
    public class GeradorPagamentoService
    {
        public static Pagamento CriarPagamento(FormaPagamento formaPagamento)
        {
            return new Pagamento 
            {
                Id = Guid.NewGuid(),
                Cliente = "Cliente Exemplo",
                ValorOriginal = 100m,
                FormaPagamento = formaPagamento,
                Parcelas = formaPagamento == FormaPagamento.CartaoCredito ? 3 : 1
            };
        }
    }
}
