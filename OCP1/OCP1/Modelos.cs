using System;

namespace OCP1;

public enum TipoEntrega
{
    Normal,
    Expressa,
    RetiradaLoja,
    Agendada
}

public class Pedido
{
    public Guid Id { get; set; }
    public decimal ValorProdutos { get; set; }
    public TipoEntrega TipoEntrega { get; set; }
    public decimal DistanciaKm { get; set; }
}
