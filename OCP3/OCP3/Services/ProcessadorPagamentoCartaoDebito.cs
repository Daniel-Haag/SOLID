using OCP3.Enums;
using OCP3.Interfaces;
using OCP3.Models;

namespace OCP3.Services
{
    public class ProcessadorPagamentoCartaoDebito : IProcessadorPagamento
    {
        public FormaPagamento FormaPagamento => FormaPagamento.CartaoDebito;
        public ResultadoPagamento Processar(Pagamento pagamento)
        {
            return new ResultadoPagamento
            {
                ValorTaxa = pagamento.ValorOriginal * 0.02m,
                ValorFinal = pagamento.ValorOriginal + (pagamento.ValorOriginal * 0.02m),
                Mensagem = $"Pagamento com cartão de débito concluído para {pagamento.Cliente}."
            };
        }
    }
}
