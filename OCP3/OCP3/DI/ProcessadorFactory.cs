using OCP3.Enums;
using OCP3.Interfaces;
using OCP3.Models;

namespace OCP3.DI;

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
        if (!_processadores.TryGetValue(formaPagamento, out var processador))
        {
            throw new NotSupportedException($"Forma de pagamento {formaPagamento} nao suportada.");
        }

        return processador;
    }
}
