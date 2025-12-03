namespace LojaOCP
{
    public class ResultadoPedido : Pedido
    {
        public decimal ValorProdutos { get; set; }
        public decimal Desconto { get; set; }
        public decimal Frete { get; set; }
        public decimal ValorFinal { get; set; }
    }
}
