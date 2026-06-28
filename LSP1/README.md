# Projeto LSP1 - Versao Refatorada com LSP

## Cenario
Sistema simples com um **caixa eletronico** que realiza saque em contas bancarias.

Na versao inicial, o servico `CaixaEletronicoService` trabalhava com `ContaBancaria` e assumia que:

- toda conta bancaria pode tentar sacar
- se houver saldo suficiente, o saque pode ser realizado
- se nao houver saldo, o metodo apenas retorna `false`

## Onde estava a violacao de LSP?
A classe `ContaInvestimento` herdava de `ContaBancaria`, mas nao conseguia cumprir o contrato implicito de saque.

Em vez de manter o comportamento esperado da classe base, ela lanca uma excecao em `Sacar`.

Isso significa que `ContaInvestimento` **nao pode substituir** `ContaBancaria` com seguranca no `CaixaEletronicoService`.

## Como ficou
- `ContaBancaria` agora guarda apenas o que e comum a qualquer conta
- `IContaBancariaSaque` representa a capacidade de sacar
- `IContaBancariaDeposito` representa a capacidade de depositar
- `ContaCorrente` implementa saque e deposito
- `ContaInvestimento` implementa apenas deposito
- `CaixaEletronicoService` depende do contrato de saque, nao de qualquer conta bancaria

## Como rodar
```bash
dotnet build
dotnet run --project LSP1
```
