namespace OCP2.Models;

public class ItemVendido
{
    public string Produto { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public decimal ValorTotal { get; set; }
}
