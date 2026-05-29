namespace OCP3.Models;

public class ResultadoPagamento
{
    public decimal ValorTaxa { get; set; }
    public decimal ValorFinal { get; set; }
    public string Mensagem { get; set; } = string.Empty;
}
