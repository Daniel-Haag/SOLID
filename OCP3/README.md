# Projeto OCP3 - Versao que VIOLA OCP (Open/Closed Principle)

## Cenario
Sistema simples que processa pagamentos em formas diferentes:

- `Pix`
- `CartaoCredito`
- `Boleto`
- `CarteiraDigital`

Cada forma de pagamento possui regra propria de:

- taxa
- valor final
- mensagem de confirmacao

## Onde esta a violacao de OCP?
A classe `ProcessadorPagamentoService` usa `switch` para decidir como processar cada pagamento.
Sempre que surgir uma nova forma (ex.: `Debito` ou `Criptomoeda`), voce tera que **MODIFICAR** o metodo `Processar`.

## Sua missao
Refatorar para deixar o projeto **aberto para extensao e fechado para modificacao**.

Sugestao:
- criar uma abstracao como `IProcessadorPagamento`
- ter uma classe por forma de pagamento
- fazer o fluxo principal depender da abstracao, nao do `switch`

## Desafio extra
Adicionar uma nova forma de pagamento, como `Debito`, sem mexer na classe principal de processamento.

## Como rodar
```bash
dotnet build
dotnet run --project OCP3
```
