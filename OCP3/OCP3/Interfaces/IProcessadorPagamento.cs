using OCP3.Enums;
using OCP3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCP3.Interfaces
{
    public interface IProcessadorPagamento
    {
        public FormaPagamento FormaPagamento { get; }
        public ResultadoPagamento Processar(Pagamento pagamento);
    }
}
