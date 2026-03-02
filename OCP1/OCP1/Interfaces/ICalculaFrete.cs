using OCP1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCP1.Interfaces
{
    public interface ICalculaFreteService
    {
        decimal Calcular(Pedido pedido);
    }
}
