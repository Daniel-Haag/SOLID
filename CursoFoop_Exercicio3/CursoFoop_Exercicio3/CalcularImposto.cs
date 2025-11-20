namespace CursoFoop_Exercicio3
{
    class CalcularImposto
    {
        public static decimal Calcular(decimal valor, decimal deducao, string pais)
        {
            decimal valorImposto = 0;
            decimal valorBase = valor - deducao;
            switch (pais)
            {
                case "Brazil":
                    //código cálculo
                    break;
                case "USA":
                    //código cálculo
                    break;
                case "UK":
                    //código cálculo
                    break;
            }
            return valorImposto;
        }
    }
}
