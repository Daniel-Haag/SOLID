# Projeto OCP2 - Versao Refatorada com OCP

## Cenario
Sistema simples que exporta um **relatorio de vendas** em formatos diferentes:

- `Csv`
- `Json`
- `Xml`
- `Html`

## Como ficou
- Cada formato tem sua propria classe e implementa `IExportadorRelatorioService`
- A classe `ExportadorRelatorioService` recebe todas as implementacoes por construtor
- O fluxo principal pede a exportacao por `FormatoExportacao`, sem conhecer a logica concreta de cada formato

## Como estender
Para adicionar um novo formato:

1. Crie uma nova classe que implemente `IExportadorRelatorioService`
2. Informe o `Formato` suportado por essa classe
3. Registre a nova implementacao na composicao principal do programa

## Como rodar
```bash
dotnet build
dotnet run --project OCP2
```
