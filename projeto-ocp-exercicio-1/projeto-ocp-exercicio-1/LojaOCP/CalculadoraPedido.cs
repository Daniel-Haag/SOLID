using LojaOCP.Interfaces;

namespace LojaOCP
{
    /// <summary>
    /// Esta classe VIOLA OCP de propósito.
    /// Qualquer novo tipo de cliente ou entrega obriga a alterar este código.
    /// </summary>
    public class CalculadoraPedido
    {
        //Abstraí a lógica variável para aplicar o padrão Strategy e respeitar OCP
        private ICalculadoraDescontoPedido _calculadoraDescontoPedido;
        private ICalculadoraFretePedido _calculadoraFretePedido;
        
        public CalculadoraPedido(
            ICalculadoraDescontoPedido calculadoraDescontoPedido,
            ICalculadoraFretePedido calculadoraFretePedido)
        {
            _calculadoraDescontoPedido = calculadoraDescontoPedido;
            _calculadoraFretePedido = calculadoraFretePedido;
        }
        
        public ResultadoPedido CalcularValorFinal(Pedido pedido)
        {
            var resultadoPedido = _calculadoraDescontoPedido.CalcularValorFinal(pedido);
            resultadoPedido = _calculadoraFretePedido.CalcularFretePedido(resultadoPedido, pedido);
            
            // Cálculo do valor final
            resultadoPedido.ValorFinal = pedido.ValorProdutos - resultadoPedido.Desconto + resultadoPedido.Frete;
            return resultadoPedido;
        }
        
        //Código original abaixo que viola OCP:
        
        // public ResultadoPedido CalcularValorFinal(Pedido pedido)
        // {
        //     var resultado = new ResultadoPedido
        //     {
        //         ValorProdutos = pedido.ValorProdutos
        //     };
        //
        //     // 1) Cálculo de desconto baseado em TIPO DE CLIENTE
        //     // Se surgirem novos tipos de cliente, este código terá que ser alterado.
        //     switch (pedido.TipoCliente)
        //     {
        //         case TipoCliente.Comum:
        //             // Cliente comum ganha 5% de desconto se comprar acima de 100
        //             if (pedido.ValorProdutos >= 100m)
        //             {
        //                 resultado.Desconto = pedido.ValorProdutos * 0.05m;
        //             }
        //             break;
        //
        //         case TipoCliente.Vip:
        //             // Cliente VIP sempre ganha 10% de desconto
        //             resultado.Desconto = pedido.ValorProdutos * 0.10m;
        //             break;
        //
        //         case TipoCliente.Funcionario:
        //             // Funcionário ganha 20% de desconto, mas limitado a 50 reais
        //             var descontoBruto = pedido.ValorProdutos * 0.20m;
        //             resultado.Desconto = Math.Min(descontoBruto, 50m);
        //             break;
        //
        //         default:
        //             // Se no futuro adicionarem novos tipos e esquecerem de tratar aqui,
        //             // o comportamento ficará inconsistente.
        //             break;
        //     }
        //
        //     // 2) Cálculo de frete baseado em TIPO DE ENTREGA
        //     // Novos tipos de entrega também exigem alteração nesta classe.
        //     switch (pedido.TipoEntrega)
        //     {
        //         case TipoEntrega.Normal:
        //             // Frete normal: 5 reais + 1 real por km
        //             resultado.Frete = 5m + (pedido.DistanciaKm * 1m);
        //             break;
        //
        //         case TipoEntrega.Expressa:
        //             // Frete expresso: 10 reais + 2 reais por km
        //             resultado.Frete = 10m + (pedido.DistanciaKm * 2m);
        //             break;
        //
        //         case TipoEntrega.RetiradaLoja:
        //             // Retirada em loja não paga frete
        //             resultado.Frete = 0m;
        //             break;
        //
        //         default:
        //             break;
        //     }
        //
        //     // 3) Cálculo do valor final
        //     resultado.ValorFinal = pedido.ValorProdutos - resultado.Desconto + resultado.Frete;
        //
        //     return resultado;
        // }
    }
}
