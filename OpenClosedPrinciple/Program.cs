using OpenClosedPrinciple.Entidades;
using OpenClosedPrinciple.Servicos;

Console.WriteLine("Informe o tipo de contrato:");
string contrato = Console.ReadLine();

if (contrato == "Estagio")
{
    FolhaDePagamentoService service = new FolhaDePagamentoService();
    Console.WriteLine(service.CalcularSalario(new Estagio()));
}

if (contrato == "ContratoClt")
{
    FolhaDePagamentoService service = new FolhaDePagamentoService();
    Console.WriteLine(service.CalcularSalario(new ContratoClt()));
}


Console.Read();
