# Projeto LSP1 - Versao que VIOLA LSP (Liskov Substitution Principle)

## Cenario
Sistema simples com um **caixa eletronico** que realiza saque em contas bancarias.

O servico `CaixaEletronicoService` trabalha com a abstracao `ContaBancaria` e assume que:

- toda conta bancaria pode tentar sacar
- se houver saldo suficiente, o saque pode ser realizado
- se nao houver saldo, o metodo apenas retorna `false`

## Onde esta a violacao de LSP?
A classe `ContaInvestimento` herda de `ContaBancaria`, mas nao consegue cumprir o contrato implicito de saque.

Em vez de manter o comportamento esperado da classe base, ela lanca uma excecao em `Sacar`.

Isso significa que `ContaInvestimento` **nao pode substituir** `ContaBancaria` com seguranca no `CaixaEletronicoService`.

## Sua missao
Refatorar o modelo para respeitar o **Liskov Substitution Principle**.

Sugestoes:
- separar melhor as abstracoes
- evitar que uma classe herde um comportamento que ela nao consegue cumprir
- considerar interfaces mais especificas para contas que realmente permitem saque

## Como rodar
```bash
dotnet build
dotnet run --project LSP1
```
