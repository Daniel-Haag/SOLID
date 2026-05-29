namespace OCP2.Models;

public class RelatorioDeVendas
{
    public string Titulo { get; set; } = string.Empty;
    public string Periodo { get; set; } = string.Empty;
    public string Responsavel { get; set; } = string.Empty;
    public decimal TotalVendido { get; set; }
    public int QuantidadePedidos { get; set; }
    public List<ItemVendido> Itens { get; set; } = new();
}
