using OCP3.Enums;

namespace OCP3.Models;

public class Pagamento
{
    public Guid Id { get; set; }
    public string Cliente { get; set; } = string.Empty;
    public decimal ValorOriginal { get; set; }
    public int Parcelas { get; set; }
    public FormaPagamento FormaPagamento { get; set; }
}
