# Projeto OCP1 — Versão que VIOLA OCP (Open/Closed Principle)

## Cenário (regra de negócio)
Sistema simples que calcula **frete** conforme o **tipo de entrega**:

- `Normal`: R$ 10,00 + R$ 1,00 por km
- `Expressa`: R$ 20,00 + R$ 2,00 por km
- `RetiradaLoja`: R$ 0,00
- `Agendada`: R$ 15,00 + R$ 1,50 por km

## Onde está a violação de OCP?
A classe `CalculadoraFrete` usa `switch` para decidir o cálculo.
Sempre que surgir um novo tipo (ex.: `Drone`), você terá que **MODIFICAR** o método `Calcular`.

## Sua missão
Refatorar para ficar **aberto para extensão e fechado para modificação**.
Sugestão: Strategy + Interfaces (ex.: `ICalculoFrete`).

## Como rodar
```bash
dotnet build
dotnet run --project OCP1
```
