using OpenClosedPrinciple.Interfaces;

namespace OpenClosedPrinciple.Servicos
{
    public class FolhaDePagamentoService
    {
        protected readonly decimal saldo;

        public decimal CalcularSalario(IRemuneravel contrato)
        {
            return contrato.ObterRemuneracao();
        }
    }
}
