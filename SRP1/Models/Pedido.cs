namespace SRP1.Models;

public class Pedido
{
    public int Id { get; set; }
    public string NomeCliente { get; set; } = string.Empty;
    public string EmailCliente { get; set; } = string.Empty;
    public List<ItemPedido> Itens { get; set; } = [];
    public decimal Total => Itens.Sum(i => i.Preco * i.Quantidade);
}

public class ItemPedido
{
    public string Produto { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public decimal Preco { get; set; }
}
