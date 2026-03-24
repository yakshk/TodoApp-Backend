# Yaksh's Todo App Api

A production-grade RESTful API built with .NET 10, designed around Clean Architecture principles to ensure long-term maintainability, testability, and scalability.

100% test coverage of all logic files.

### [Frontend](https://github.com/yakshk/TodoApp-Frontend)

`https://github.com/yakshk/TodoApp-Frontend`

The backend was separated to avoid creating a monolithic repository, which can quickly become difficult to scale, maintain, and evolve in an enterprise environment.

---

## Architecture Overview

The solution is structured into three projects, each with a clearly defined responsibility:

```
TodoAppBackend.sln
├── Application/          # Core business logic, fully framework-agnostic
│   ├── DTOs/             # Data transfer objects for clean API contracts
│   ├── Extensions/       # Reusable extension methods
│   ├── Handlers/         # CQRS-style handlers
│   ├── Interfaces/       # Abstractions that decouple Application from Infrastructure
│   ├── Models/           # Domain models representing core business entities
│   └── Requests/         # Strongly-typed request objects for handler dispatch
│
├── Infrastructure/       # Persistence, external services
│   └── Repositories/     # Implementations of Application interfaces
│
└── TodoApi/              # Presentation layer, HTTPS entry point
    └── Controllers/      # RESTful controllers, thin, delegating to handlers
```

---

## Key Design Decisions

### Clean Architecture

Business logic lives exclusively in the `Application` layer, isolated from technical concerns.

### Handler Pattern (CQRS-Aligned)

Business operations are encapsulated in discrete handler classes, each responsible for a single query. This eliminates bloated service classes and helps improve testability.

### RESTful Controller Design

Controllers in `TodoApi` are intentionally thin. They translate HTTP concerns, no business logic resides in a controller.

---

## Technology Stack

Framework: .Net 10

Language: C#

---

## Running the API

```bash
dotnet restore
dotnet run --project TodoApi --launch-profile https
```

The API will be available at `https://localhost:7273` by default. Swagger UI is accessible at `/swagger` in development mode.

### Running Tests

```bash
dotnet test
```

---

## API Endpoints

| Method | Endpoint                         | Description              |
| ------ | -------------------------------- | ------------------------ |
| GET    | `/api/todos/getAll`              | Retrieve all todo items  |
| POST   | `/api/todos/create`              | Create a new todo item   |
| PATCH  | `/api/todos/toggleComplete/{id}` | Toggle completion status |
| DELETE | `/api/todos/delete/{id}`         | Delete a todo item       |
