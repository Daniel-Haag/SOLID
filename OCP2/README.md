# Projeto OCP2 - Versao que VIOLA OCP (Open/Closed Principle)

## Cenario
Sistema simples que exporta um **relatorio de vendas** em formatos diferentes:

- `Csv`
- `Json`
- `Xml`
- `Html`

## Onde esta a violacao de OCP?
A classe `ExportadorRelatorioService` usa `switch` para decidir como exportar.
Sempre que surgir um novo formato (ex.: `Markdown` ou `Pdf`), voce tera que **MODIFICAR** o metodo `Exportar`.

## Sua missao
Refatorar para deixar o projeto **aberto para extensao e fechado para modificacao**.

Sugestao:
- Criar uma abstracao como `IExportadorRelatorio`
- Ter uma classe por formato
- Fazer o fluxo principal depender da abstracao, nao do `switch`

## Desafio extra
Adicionar um novo formato, como `Markdown`, sem mexer na classe principal de exportacao.

## Como rodar
```bash
dotnet build
dotnet run --project OCP2
```
