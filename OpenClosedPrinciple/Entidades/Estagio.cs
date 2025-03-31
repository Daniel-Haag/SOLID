using OpenClosedPrinciple.Interfaces;

namespace OpenClosedPrinciple.Entidades
{
    public class Estagio : IRemuneravel
    {
        public decimal ObterRemuneracao()
        {
            return 2.000M;
        }
    }
}
