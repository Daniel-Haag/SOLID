using OCP3.DI;
using OCP3.Models;

namespace OCP3.Services;

/// <summary>
/// Serviço responsável por processar pagamentos,
/// utilizando a ProcessadorFactory para obter a implementação correta
/// </summary>
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
