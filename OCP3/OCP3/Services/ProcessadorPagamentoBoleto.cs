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
    /// Classe responsável por processar pagamentos via boleto, implementando a interface IProcessadorPagamento.
    /// </summary>
    public class ProcessadorPagamentoBoleto : IProcessadorPagamento
    {
        public FormaPagamento FormaPagamento => FormaPagamento.Boleto;

        public ResultadoPagamento Processar(Pagamento pagamento)
        {
            return new ResultadoPagamento
            {
                ValorTaxa = 2.50m,
                ValorFinal = pagamento.ValorOriginal + 2.50m,
                Mensagem = $"Boleto gerado para {pagamento.Cliente} com vencimento em 3 dias."
            };
        }
    }
}
