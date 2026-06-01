using Microsoft.Extensions.DependencyInjection;
using OCP3.Interfaces;
using OCP3.Services;

namespace OCP3.DI;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddProcessamentoPagamentos(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        var contrato = typeof(IProcessadorPagamento);
        var assembly = typeof(ServiceCollectionExtensions).Assembly;

        var tiposDeProcessador = assembly
            .GetTypes()
            .Where(tipo => !tipo.IsAbstract && !tipo.IsInterface && contrato.IsAssignableFrom(tipo));

        foreach (var tipo in tiposDeProcessador)
        {
            services.AddSingleton(contrato, tipo);
        }

        services.AddSingleton<ProcessadorFactory>();
        services.AddSingleton<ProcessadorPagamentoService>();

        return services;
    }
}
