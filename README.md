# Projeto de Investimento Bancário — *Sprint 4* - C#

## Visão Geral

Este projeto tem como objetivo o desenvolvimento de uma **API RESTful para gestão de investimentos de clientes bancários**, permitindo o cadastro de clientes, criação e gerenciamento de investimentos associados, e controle centralizado por meio de endpoints documentados via Swagger.

A aplicação foi construída em **C# com .NET 8**, utilizando **Entity Framework Core** para persistência de dados e arquitetura em camadas (Controller → Service → Repository → Data → Model).

---

## Objetivo do Sistema

O sistema tem como foco oferecer um **gerenciador de investimentos** simples e eficiente para clientes de um banco fictício.  

Os principais objetivos são:
- Permitir o **cadastro de clientes** e de seus respectivos **investimentos**.
- Facilitar a **consulta de informações** financeiras por meio de endpoints REST.
- Garantir que cada investimento esteja **associado a um cliente** por meio de um relacionamento direto.
- Automatizar a **data de criação dos investimentos** no momento do registro.

---

## Tecnologias e Ferramentas Utilizadas

| Camada | Ferramenta / Tecnologia |
|--------|--------------------------|
| **Linguagem** | C# (.NET 8) |
| **Framework** | ASP.NET Core Web API |
| **ORM** | Entity Framework Core |
| **Banco de Dados** | SQLite (via `investimentos.db`) |
| **Documentação da API** | Swagger / Swashbuckle |
| **IDE Recomendada** | Visual Studio 2022 |
| **Padrão de Arquitetura** | MVC + Repository + DTO |
| **Dependências Principais** | `Microsoft.EntityFrameworkCore`, `Microsoft.EntityFrameworkCore.Sqlite`, `Swashbuckle.AspNetCore` |

---

## Instruções de execução

1. Clonar o projeto
```bash
git clone https://github.com/linesiscl/Challenge_Sprint4_CSharp.git
```

2. Executar o projeto pelo terminal
```
cd sprint4
dotnet run
```

---

## Estrutura do Projeto

```
sprint4/
│
├── controller/
│ ├── ClienteController.cs
│ └── InvestimentoController.cs
│
├── data/
│ └── AppDbContext.cs
│
├── dto/
│ ├── ClienteDTO.cs
│ ├── CriaClienteDTO.cs
│ ├── CriaInvestimentoDTO.cs
│ └── InvestimentoDTO.cs
│
├── model/
│ ├── Cliente.cs
│ ├── Conta.cs
│ ├── Investimento.cs
│ └── Transacao.cs
│
├── repository/
│ ├── IRepositorio.cs
│ ├── Repositorio.cs
│ └── RepositorioInvest.cs
│
├── service/
│ ├── IServiceInvest.cs
│ └── ServiceInvest.cs
│
├── Migrations/
│ ├── 20251019144854_InitialCreate.cs
│ └── AppDbContextModelSnapshot.cs
│
├── Program.cs
├── appsettings.json
├── investimentos.db
├── investimentos.db-shm
└── investimentos.db-wal
```

---

## Principais Endpoints (Swagger)

Após iniciar o projeto, acesse:
`https://localhost:{porta}/swagger`

### Cliente
- **GET** `/api/cliente` — Listar todos os clientes  
- **POST** `/api/cliente` — Cadastrar novo cliente  
- **GET** `/api/cliente/{id}` — Obter cliente por ID  
- **DELETE** `/api/cliente/{id}` — Excluir cliente  

### Investimento
- **GET** `/api/investimento` — Listar todos os investimentos (com cliente vinculado)  
- **POST** `/api/investimento` — Criar novo investimento vinculado a um cliente existente  
- **PUT** `/api/investimento/{id}` — Atualizar investimento existente  
- **DELETE** `/api/investimento/{id}` — Excluir investimento  

---

## Diagrama de Arquitetura

<img width="3788" height="1420" alt="image" src="https://github.com/user-attachments/assets/49265e9a-ecb7-43b0-95be-e356e248eff6" />

