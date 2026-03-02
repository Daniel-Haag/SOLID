using OCP1.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCP1.Models
{
    public class Pedido
    {
        public Guid Id { get; set; }
        public decimal ValorProdutos { get; set; }
        public TipoEntrega TipoEntrega { get; set; }
        public decimal DistanciaKm { get; set; }
    }
}
