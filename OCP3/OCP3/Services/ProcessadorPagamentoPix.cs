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
    /// Classe responsável por processar pagamentos via Pix, implementando a interface IProcessadorPagamento.
    /// </summary>
    public class ProcessadorPagamentoPix : IProcessadorPagamento
    {
        public FormaPagamento FormaPagamento => FormaPagamento.Pix;

        public ResultadoPagamento Processar(Pagamento pagamento)
        {
            return new ResultadoPagamento 
            {
                ValorTaxa = 0m,
                ValorFinal = pagamento.ValorOriginal,
                Mensagem = $"Pagamento via Pix aprovado instantaneamente para {pagamento.Cliente}."        
            };
        }
    }
}
