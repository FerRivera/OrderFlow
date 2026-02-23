# OrderFlow (Orders)

Clean Architecture Orders service built with **.NET 8**, **PostgreSQL (Docker)**, and **EF Core migrations**.

## Solution structure
- `OrderFlow.Orders.Api` — HTTP API (Swagger), composition root
- `OrderFlow.Orders.Application` — Use cases, interfaces (abstractions)
- `OrderFlow.Orders.Domain` — Entities + domain rules
- `OrderFlow.Orders.Infrastructure` — EF Core DbContext + persistence implementations
- `docker-compose.yml` — Local Postgres for development

## Prerequisites
- .NET 8 SDK
- Docker Desktop

## Run Postgres (local)
From the solution root:

```bash
docker compose up -d
```

DB default (local):
- Host: `localhost`
- Port: `5432`
- Database: `orderflow_orders`
- Username: `orderflow`
- Password: `<set locally>`

## Configure connection string (local only)
Create `OrderFlow.Orders.Api/appsettings.Development.json` (ignored by git):

```json
{
  "ConnectionStrings": {
    "OrdersDb": ""
  }
}
```

> `appsettings.json` keeps `OrdersDb` empty to avoid committing secrets.

## Run the API
From the solution root:

```bash
dotnet run --project OrderFlow.Orders.Api
```

Then open Swagger (usually):
- `https://localhost:xxxx/swagger` (Visual Studio will show the exact port)

## EF Core migrations
Package Manager Console:
- Default project: `OrderFlow.Orders.Infrastructure`
- Startup project: `OrderFlow.Orders.Api`

Commands:

```powershell
Add-Migration InitialCreate -StartupProject OrderFlow.Orders.Api
Update-Database -StartupProject OrderFlow.Orders.Api
```

## Next step
Persist an Order from `POST /api/orders` using an Application abstraction (repository) + EF implementation in Infrastructure.
