using OCP2.Enums;
using OCP2.Models;

namespace OCP2.Interfaces;

public interface IExportadorRelatorioService
{
    FormatoExportacao Formato { get; }
    ResultadoExportacao Exportar(RelatorioDeVendas relatorio);
}
