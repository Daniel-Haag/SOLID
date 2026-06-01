using OCP3.Enums;
using OCP3.Interfaces;
using OCP3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCP3.Services
{
    /// <summary>
    /// Classe responsável por processar pagamentos via cartão de crédito, implementando a interface IProcessadorPagamento.
    /// </summary>
    public class ProcessadorPagamentoCartaoCredito : IProcessadorPagamento   
    {
        public FormaPagamento FormaPagamento => FormaPagamento.CartaoCredito;

        public ResultadoPagamento Processar(Pagamento pagamento)
        {
            return new ResultadoPagamento
            {
                ValorTaxa = pagamento.ValorOriginal * 0.0399m,
                ValorFinal = pagamento.ValorOriginal + (pagamento.ValorOriginal * 0.0399m),
                Mensagem = $"Pagamento no cartao em {pagamento.Parcelas}x autorizado para {pagamento.Cliente}."
            };
        }
    }
}
