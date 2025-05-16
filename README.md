## 📌 Descrição do Projeto

Esta é a **API de Vendas** da DeveloperStore, responsável por registrar e consultar vendas realizadas nos diversos pontos de venda da rede.

A API segue princípios de DDD (Domain-Driven Design), com aplicação do padrão **External Identities** para integrar dados de clientes, produtos e filiais. Além disso, respeita regras de negócio de descontos por quantidade e publica eventos relevantes no domínio (via logs).

## ✅ Funcionalidades Implementadas

- [x] Criar e consultar vendas
- [x] Aplicação automática de descontos por quantidade:
  - 4 a 9 unidades: 10%
  - 10 a 20 unidades: 20%
  - Mais de 20: não permitido
- [x] Cálculo automático do valor total da venda e dos itens
- [x] Suporte a múltiplos produtos por venda

## 🧠 Tecnologias Utilizadas

| Tecnologia            | Finalidade                                 |
| --------------------- | ------------------------------------------ |
| ASP.NET Core          | Framework principal para construção da API |
| MediatR               | Aplicação de padrões DDD/CQRS              |
| Entity Framework      | Acesso a dados com persistência em SQL     |
| AutoMapper            | Mapeamento entre DTOs e entidades          |
| FluentValidation      | Validações de entrada e regras de negócio  |
| Swagger (Swashbuckle) | Documentação e testes dos endpoints        |

## 🚀 Guia de Instalação e Execução

### Pré-requisitos

- [.NET SDK 7.0+](https://dotnet.microsoft.com/download)
- [PostgreSQL 14+](https://www.postgresql.org/download/)

### Executando Localmente

### 1. Clone o repositório  

```
bash git clone https://github.com/seu-usuario/developerstore-sales-api.git
cd developerstore-sales-api
```

### 2. Configure a string de conexão PostgreSQL

No arquivo `appsettings.Development.json`, edite a conexão para:
`
"ConnectionStrings": {
	"DefaultConnection": "Host=localhost;Port=5432;Database=developerstore;Username=postgres;Password=senha" 
}
`
### 3. Restaure os pacotes e execute as migrações

`dotnet restore dotnet ef database update`

### 4. Execute a aplicação

`dotnet run`