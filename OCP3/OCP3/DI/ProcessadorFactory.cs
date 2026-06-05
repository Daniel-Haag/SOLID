using OCP3.Enums;
using OCP3.Interfaces;
using OCP3.Models;

namespace OCP3.DI;

/// <summary>
/// Classe responsável por fornecer a implementação correta de 
/// IProcessadorPagamento com base na forma de pagamento do Pagamento.
/// </summary>
public class ProcessadorFactory
{
    private readonly IReadOnlyDictionary<FormaPagamento, IProcessadorPagamento> _processadores;

    public ProcessadorFactory(IEnumerable<IProcessadorPagamento> processadores)
    {
        ArgumentNullException.ThrowIfNull(processadores);
        _processadores = processadores.ToDictionary(processador => processador.FormaPagamento);
    }

    public IProcessadorPagamento Obter(Pagamento pagamento)
    {
        ArgumentNullException.ThrowIfNull(pagamento);
        return Obter(pagamento.FormaPagamento);
    }

    public IProcessadorPagamento Obter(FormaPagamento formaPagamento)
    {
        // Tenta obter o processador correspondente à forma de pagamento.
        // Se não encontrar, lança uma exceção indicando que a forma de pagamento não é suportada.
        // Os processadores já estão pré-carregados no dicionário durante a construção da fábrica, garantindo acesso rápido.
        if (!_processadores.TryGetValue(formaPagamento, out var processador))
        {
            throw new NotSupportedException($"Forma de pagamento {formaPagamento} nao suportada.");
        }

        return processador;
    }
}
