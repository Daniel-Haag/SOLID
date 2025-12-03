# Projeto OCP — Versão "Estragada" (para treinar Open/Closed Principle)

## Contexto de Negócio

Temos uma **loja online** que calcula o **valor final de um pedido** com base em:

- Tipo de cliente:
  - `Comum`
  - `Vip`
  - `Funcionario`
- Tipo de entrega:
  - `Normal`
  - `Expressa`
  - `RetiradaLoja`

A classe `CalculadoraPedido` concentra toda a lógica de cálculo de desconto e frete usando vários `if/else` e `switch`.

## Objetivo do Exercício

Este projeto **VIOLA OCP** de propósito.

Sua tarefa é:

1. Rodar o projeto para entender o fluxo atual.
2. Identificar os pontos que violam OCP (if/else crescendo para cada tipo), por exemplo:
   - tipos de cliente
   - tipos de entrega
3. Refatorar o código para ficar **aberto para extensão e fechado para modificação**, por exemplo:
   - usando estratégias (Strategy)
   - usando interfaces para desconto e frete
   - evitando editar `CalculadoraPedido` sempre que surgir um novo tipo

## Como rodar

Dentro da pasta raiz do projeto:

```bash
dotnet build
dotnet run --project LojaOCP
```

## Dica

- Imagine que amanhã vão surgir:
  - tipo de cliente `Parceiro`
  - tipo de entrega `Agendada`
- Sua refatoração deve tornar isso fácil de adicionar sem modificar código já existente na `CalculadoraPedido`.

Bom treino! Depois você pode me mandar a versão refatorada para revisarmos juntos.
