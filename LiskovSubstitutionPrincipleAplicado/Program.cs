// Liskov Substitution Principle (LSP) - Princípio da Substituição de Liskov
// Uma classe derivada deve ser substituível por sua classe base

Console.WriteLine("=== Demonstração do Princípio da Substituição de Liskov ===\n");

// Criando instâncias
A objeto1 = new A();
A objeto2 = new B();

// Demonstração do LSP
// Podemos substituir a classe base (A) pela classe derivada (B) sem alterar o comportamento do programa
Console.WriteLine(ImprimeNome(objeto1)); // Meu nome é A
Console.WriteLine(ImprimeNome(objeto2)); // Meu nome é B

Console.WriteLine("\n--- Explicação do LSP ---");
Console.WriteLine("Note que a função ImprimeNome() aceita objetos do tipo A (classe base).");
Console.WriteLine("Mas conseguimos passar tanto objeto1 (tipo A) quanto objeto2 (tipo B).");
Console.WriteLine("Isso demonstra que B pode substituir A sem quebrar o programa!");
Console.WriteLine("Este é o Princípio da Substituição de Liskov em ação.");

// Função que aceita objetos do tipo A (classe base)
static string ImprimeNome(A objeto)
{
    return objeto.GetName();
}

// Classe base A
class A
{
    public virtual string GetName()
    {
        return "Meu nome é A";
    }
}

// Classe B derivada de A
class B : A
{
    public override string GetName()
    {
        return "Meu nome é B";
    }
}
