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
    /// Classe responsável por processar pagamentos via carteira digital, implementando a interface IProcessadorPagamento.
    /// </summary>
    public class ProcessadorPagamentoCarteiraDigital : IProcessadorPagamento
    {
        public FormaPagamento FormaPagamento => FormaPagamento.CarteiraDigital;
        public ResultadoPagamento Processar(Pagamento pagamento)
        {
            return new ResultadoPagamento
            {
                ValorTaxa = pagamento.ValorOriginal * 0.015m,
                ValorFinal = pagamento.ValorOriginal + (pagamento.ValorOriginal * 0.015m),
                Mensagem = $"Pagamento com carteira digital concluido para {pagamento.Cliente}."
            };
        }
    }
}
