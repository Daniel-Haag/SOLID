using OCP1.Interfaces;
using OCP1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCP1.Services
{
    public class CalculaFreteAgendadoService : ICalculaFreteService
    {
        public decimal Calcular(Pedido pedido)
        {
            return 15m + (pedido.DistanciaKm * 1.5m);
        }
    }
}
