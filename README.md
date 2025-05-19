## 📌 Descrição do Projeto

Esta é a **API de Vendas** da DeveloperStore, responsável por registrar, consultar e cancelar vendas realizadas nos diversos pontos de venda da rede.

A API segue princípios de DDD (Domain-Driven Design), com aplicação do padrão **External Identities** para integrar dados de clientes, produtos e filiais. Além disso, respeita regras de negócio de descontos por quantidade e publica eventos relevantes no domínio (via logs).

## ✅ Funcionalidades Implementadas

- [x] Criar e consultar vendas  
- [x] Aplicação automática de descontos por quantidade:
  - 4 a 9 unidades: 10%
  - 10 a 20 unidades: 20%
  - Mais de 20: não permitido  
- [x] Cálculo automático do valor total da venda e dos itens  
- [x] Suporte a múltiplos produtos por venda  
- [x] Validações robustas para regras de negócio  
- [x] Logs detalhados de eventos de domínio  
- [x] Integração com serviços externos para dados de produtos e clientes  
- [x] O endpoint `/api/Sales` sempre retorna a venda com a lista `saleItems` vazia. Para visualizar os itens de uma venda específica, utilize o endpoint `/api/Sales/{guid}`.  
- [x] A API foi desenvolvida para não permitir a criação de vendas com produtos de mais de uma filial.  
  _Essa restrição pode ser facilmente ajustada, caso o projeto exija suporte a múltiplas filiais por venda_  
- [x] Uma venda não pode conter dois itens no corpo da requisição referenciando o mesmo produto.  
  _Se for necessário inserir dois produtos iguais, deve-se adicionar apenas um item à lista e especificar a quantidade desejada nesse item_

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

```bash
bash git clone https://github.com/seu-usuario/developerstore-sales-api.git
cd developerstore-sales-api
```

### 2. Configure a string de conexão PostgreSQL

No arquivo `appsettings.Development.json`, edite a conexão para:
```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=developerstore;Username=postgres;Password=senha"
}
```
### 3. Restaure os pacotes e execute as migrações

```bash
dotnet restore
dotnet ef database update
```

### 4. Execute a aplicação

```bash
dotnet run
```

## 🔮 Modificações Futuras

Algumas melhorias e extensões planejadas para versões futuras da API, dependendo da necessidade do projeto:

- [ ] Criar um endpoint exclusivo para listar apenas os itens de uma venda, com suporte a paginação  
  _Caso o frontend precise acessar diretamente os itens de uma venda específica_
  
- [ ] Obter informações do usuário final ou da filial a partir do token JWT nos endpoints de adição de produtos e vendas  
  _Útil caso a API esteja inserida em um ambiente com múltiplas filiais ou usuários_

- [ ] Implementar um serviço de mensageria (ex: RabbitMQ) para publicar eventos da aplicação para outros microsserviços  
  _Importante em arquiteturas baseadas em eventos e sistemas distribuídos_
