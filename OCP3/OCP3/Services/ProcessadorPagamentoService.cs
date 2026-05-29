using OCP3.Enums;
using OCP3.Models;

namespace OCP3.Services;

/// <summary>
/// Classe propositalmente violando OCP.
/// Sempre que surgir uma nova forma de pagamento, este metodo precisara ser modificado.
/// </summary>
public class ProcessadorPagamentoService
{
    public ResultadoPagamento Processar(Pagamento pagamento)
    {
        return pagamento.FormaPagamento switch
        {
            FormaPagamento.Pix => new ResultadoPagamento
            {
                ValorTaxa = 0m,
                ValorFinal = pagamento.ValorOriginal,
                Mensagem = $"Pagamento via Pix aprovado instantaneamente para {pagamento.Cliente}."
            },

            FormaPagamento.CartaoCredito => new ResultadoPagamento
            {
                ValorTaxa = pagamento.ValorOriginal * 0.0399m,
                ValorFinal = pagamento.ValorOriginal + (pagamento.ValorOriginal * 0.0399m),
                Mensagem = $"Pagamento no cartao em {pagamento.Parcelas}x autorizado para {pagamento.Cliente}."
            },

            FormaPagamento.Boleto => new ResultadoPagamento
            {
                ValorTaxa = 2.50m,
                ValorFinal = pagamento.ValorOriginal + 2.50m,
                Mensagem = $"Boleto gerado para {pagamento.Cliente} com vencimento em 3 dias."
            },

            FormaPagamento.CarteiraDigital => new ResultadoPagamento
            {
                ValorTaxa = pagamento.ValorOriginal * 0.015m,
                ValorFinal = pagamento.ValorOriginal + (pagamento.ValorOriginal * 0.015m),
                Mensagem = $"Pagamento com carteira digital concluido para {pagamento.Cliente}."
            },

            _ => throw new NotSupportedException($"Forma de pagamento {pagamento.FormaPagamento} nao suportada.")
        };
    }
}
