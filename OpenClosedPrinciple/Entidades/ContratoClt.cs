using OpenClosedPrinciple.Interfaces;

namespace OpenClosedPrinciple.Entidades
{
    public class ContratoClt : IRemuneravel
    {
        public decimal ObterRemuneracao()
        {
            return 8.000M;
        }
    }
}
