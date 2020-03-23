# AnaliseVendasApp

## Descrição:

Sistema de análise de dados de venda que irá importar lotes de arquivos e produzir
um relatório baseado em informações presentes no mesmo.
Existem 3 tipos de dados dentro dos arquivos e eles podem ser distinguidos pelo seu
identificador que estará presente na primeira coluna de cada linha, onde o separador de
colunas é o caractere “ç”.

Exemplo de modelo de arquivo a ser importado:

```
001ç1234567891234çPedroç50000
001ç3245678865434çPauloç40000.99
002ç2345675434544345çJose da SilvaçRural
002ç2345675433444345çEduardo PereiraçRural
003ç10ç[1-10-100,2-30-2.50,3-40-3.10]çPedro
003ç08ç[1-34-10,2-33-1.50,3-40-0.10]çPaulo
```

O sistema lê continuamente todos os arquivos dentro do diretório padrão
HOMEPATH/data/in e coloca o arquivo de saída em HOMEPATH/data/out.
No arquivo de saída o sistema possui os seguintes dados:
• Quantidade de clientes no arquivo de entrada
• Quantidade de vendedores no arquivo de entrada
• ID da venda mais cara
• O pior vendedor

## Requisitos

Aplicação em .NET Framework 4.7 em linguagem C#.
Foi utilizado o banco de dados SQL Server 2014 Express. Para criação do banco de dados utilizado e suas tabelas, está disponível o script na pasta do projeto em \Scripts\script_SQL_CREATE_DB_TABLES.sql
Como ferramenta ORM foi utilizado Entity Framework Core versão 2.0
