# GerenciadorTarefas

Um **sistema Web API para gerenciar tarefas**, com CRUD completo e filtros por título, data e status. Desenvolvido em **ASP.NET Core 8.0** com **Entity Framework** (InMemory Database) e **Swagger** para documentação interativa.

---

## Funcionalidades

- Cadastrar novas tarefas (`POST /Tarefa`)
- Obter todas as tarefas (`GET /Tarefa/ObterTodos`)
- Obter tarefa por ID (`GET /Tarefa/{id}`)
- Atualizar tarefa (`PUT /Tarefa/{id}`)
- Deletar tarefa (`DELETE /Tarefa/{id}`)
- Filtrar tarefas por título (`GET /Tarefa/ObterPorTitulo?titulo=...`)
- Filtrar tarefas por data (`GET /Tarefa/ObterPorData?data=yyyy-MM-dd`)
- Filtrar tarefas por status (`GET /Tarefa/ObterPorStatus?status=...`)

---
---

## Tecnologias

.NET 8.0

ASP.NET Core Web API

Entity Framework Core (InMemory)

Swagger (Swashbuckle)

C# 11

--- 

## Como Rodar

Clone ou extraia o projeto:

git clone <repo-url> GerenciadorTarefas


Acesse a pasta:

cd GerenciadorTarefas


Restaure os pacotes NuGet:

dotnet restore


Rode a aplicação:

dotnet run


Acesse o Swagger para testar os endpoints:

https://localhost:5001/swagger

## Observações

Atualmente o banco de dados é InMemory (apenas para teste). Para persistência real, substitua por SQL Server ou outro provedor de banco de dados no Program.cs.

Swagger permite testar todos os endpoints de forma interativa.

Data esperada no formato yyyy-MM-dd para filtros por data.

## Modelo Tarefa

```json
{
  "id": 0,
  "titulo": "string",
  "descricao": "string",
  "data": "2022-06-08T01:31:07.056Z",
  "status": "Pendente"
}

