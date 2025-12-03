using LojaOCP.Enums;

namespace LojaOCP
{
    public class Pedido 
    {
        public string ClienteNome { get; set; } = string.Empty;
        public TipoCliente TipoCliente { get; set; }
        public decimal ValorProdutos { get; set; }
        public TipoEntrega TipoEntrega { get; set; }
        public decimal DistanciaKm { get; set; }
    }
}
