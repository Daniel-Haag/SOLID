using System;

namespace OCP1;

/// <summary>
/// VIOLA OCP de propósito:
/// - usa switch por tipo
/// - sempre que surge um novo TipoEntrega, você precisa MODIFICAR este método.
/// </summary>
public class CalculadoraFrete
{
    public decimal Calcular(Pedido pedido)
    {
        switch (pedido.TipoEntrega)
        {
            case TipoEntrega.Normal:
                return 10m + (pedido.DistanciaKm * 1m);

            case TipoEntrega.Expressa:
                return 20m + (pedido.DistanciaKm * 2m);

            case TipoEntrega.RetiradaLoja:
                return 0m;

            case TipoEntrega.Agendada:
                return 15m + (pedido.DistanciaKm * 1.5m);

            default:
                // Cheiro ruim adicional: "default" silencioso.
                Console.WriteLine("[WARN] Tipo de entrega não reconhecido. Usando frete normal por padrão.");
                return 10m + (pedido.DistanciaKm * 1m);
        }
    }
}
