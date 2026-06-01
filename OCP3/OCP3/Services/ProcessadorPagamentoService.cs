using OCP3.DI;
using OCP3.Models;

namespace OCP3.Services;

public class ProcessadorPagamentoService
{
    private readonly ProcessadorFactory _factory;

    public ProcessadorPagamentoService(ProcessadorFactory factory)
    {
        _factory = factory;
    }

    public ResultadoPagamento Processar(Pagamento pagamento)
    {
        var processador = _factory.Obter(pagamento);
        return processador.Processar(pagamento);
    }
}
