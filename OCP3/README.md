# Projeto OCP3 - Versao Refatorada com OCP

## Cenario
Sistema simples que processa pagamentos em formas diferentes:

- `Pix`
- `CartaoCredito`
- `Boleto`
- `CarteiraDigital`
- `CartaoDebito`

Cada forma de pagamento possui regra propria de:

- taxa
- valor final
- mensagem de confirmacao

## Como ficou
- Cada forma de pagamento tem sua propria classe e implementa `IProcessadorPagamento`
- A classe `ProcessadorPagamentoService` orquestra o fluxo principal
- A `ProcessadorFactory` resolve o processador correto com base em `pagamento.FormaPagamento`
- O registro dos processadores e automatico por varredura da assembly

## Como estender
Para adicionar uma nova forma de pagamento:

1. Adicione o novo valor no enum `FormaPagamento`
2. Crie uma classe que implemente `IProcessadorPagamento`
3. Informe a propriedade `FormaPagamento` correspondente

Se a nova classe estiver na mesma assembly, ela sera registrada automaticamente.

## Como rodar
```bash
dotnet build
dotnet run --project OCP3
```
