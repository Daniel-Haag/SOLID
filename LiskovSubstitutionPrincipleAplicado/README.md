# Liskov Substitution Principle (LSP)

## Princípio da Substituição de Liskov

> **Uma classe derivada deve ser substituível por sua classe base.**

## Definição

O princípio da substituição de Liskov foi introduzido por **Barbara Liskov** em sua conferência "Data abstraction" em 1987. 

### Definição Formal

A definição formal de Liskov diz que:

> Se para cada objeto o1 do tipo S há um objeto o2 do tipo T de forma que, para todos os programas P definidos em termos de T, o comportamento de P é inalterado quando o1 é substituído por o2 então S é um subtipo de T.

### Definição Simplificada

> Se S é um subtipo de T, então os objetos do tipo T, em um programa, podem ser substituídos pelos objetos de tipo S sem que seja necessário alterar as propriedades deste programa. — Wikipedia

## Exemplo Prático em C#

Este projeto demonstra o LSP através de um exemplo simples:

```csharp
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

// Função que aceita objetos do tipo A (classe base)
static string ImprimeNome(A objeto)
{
    return objeto.GetName();
}

// Criando instâncias
A objeto1 = new A();
A objeto2 = new B();

// Demonstração do LSP
Console.WriteLine(ImprimeNome(objeto1)); // Meu nome é A
Console.WriteLine(ImprimeNome(objeto2)); // Meu nome é B
```

## Como o LSP é Demonstrado

1. **Classe Base (A)**: Define o comportamento básico através do método `GetName()`

2. **Classe Derivada (B)**: Herda de A e sobrescreve o método `GetName()` mantendo o contrato

3. **Função ImprimeNome()**: Aceita objetos do tipo A (classe base) como parâmetro

4. **Substituibilidade**: 
   - `objeto1` é do tipo A
   - `objeto2` é do tipo B (mas declarado como tipo A)
   - Ambos podem ser passados para `ImprimeNome()` sem quebrar o programa

## Por que isso é importante?

O LSP garante que:

- ✅ O código é mais flexível e reutilizável
- ✅ As classes derivadas mantêm o contrato da classe base
- ✅ Não há surpresas ou comportamentos inesperados ao usar polimorfismo
- ✅ O programa permanece consistente mesmo usando subtipos

## Violações Comuns do LSP

❌ **Exemplo de violação**:

```csharp
class Rectangle
{
    public virtual int Width { get; set; }
    public virtual int Height { get; set; }
}

class Square : Rectangle
{
    public override int Width
    {
        set { base.Width = base.Height = value; }
    }
    
    public override int Height
    {
        set { base.Width = base.Height = value; }
    }
}
```

Este é o famoso exemplo "Square/Rectangle" onde um quadrado (Square) não pode realmente substituir um retângulo (Rectangle) sem alterar o comportamento esperado do programa.

## Como Executar o Projeto

```bash
dotnet run
```

## Resultado Esperado

```
=== Demonstração do Princípio da Substituição de Liskov ===

Meu nome é A
Meu nome é B

--- Explicação do LSP ---
Note que a função ImprimeNome() aceita objetos do tipo A (classe base).
Mas conseguimos passar tanto objeto1 (tipo A) quanto objeto2 (tipo B).
Isso demonstra que B pode substituir A sem quebrar o programa!
Este é o Princípio da Substituição de Liskov em ação.
```

## Conclusão

O Princípio da Substituição de Liskov é fundamental para criar hierarquias de classes robustas e confiáveis. Ele garante que o polimorfismo funcione corretamente e que o código seja mantível e extensível.

---

**Parte da série SOLID:**
- **S** - Single Responsibility Principle
- **O** - Open/Closed Principle
- **L** - **Liskov Substitution Principle** ← Você está aqui
- **I** - Interface Segregation Principle
- **D** - Dependency Inversion Principle

