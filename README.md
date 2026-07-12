# POS — Point of Sale API

A backend API for a Point of Sale (POS) system, built with **.NET 8**, **Clean Architecture**, **CQRS (MediatR)**, and **Dapper**.

## Tech Stack

- **.NET 8 / ASP.NET Core Web API**
- **MediatR** — CQRS-style command/query handling
- **Dapper** — lightweight micro-ORM for data access
- **Microsoft.Data.SqlClient** — SQL Server connectivity
- **Swashbuckle (Swagger)** — API documentation & testing UI

## Project Structure

The solution follows a layered/Clean Architecture approach, separating concerns across four projects:

```
POS/
├── POS.API/          # Web API layer — controllers, startup/configuration
├── POS.DOMAIN/       # Business logic — CQRS commands, queries, handlers, services
├── POS.DATABASE/     # Data access layer — DB connection factory
├── POS.SHARED/       # Shared/common types — base controller, Result wrapper
└── POS.slnx          # Solution file
```

Each feature under `POS.DOMAIN/Features` is organized by domain area, for example:

```
Features/
└── MenuCategory/
    ├── Command/        # CreateMenuCagCommand, UpdateMenuCagCommand, DeleteMenuCagCommand
    ├── Queries/         # GetMenuCagAllQuery
    ├── Handler/         # MediatR request handlers
    ├── Models/          # Request/response DTOs
    ├── MenuCagService.cs
    └── IMenuCag.cs
```

Every request/response returns a consistent `Result<T>` wrapper (`POS.SHARED/Result.cs`) that indicates success, data, and error messages.

## Features

Currently implemented:

- **Menu Category** management
  - Get all menu categories
  - Create a menu category
  - Update a menu category
  - Delete (soft delete) a menu category

More POS features (products, orders, inventory, etc.) can be added following the same feature-folder pattern.

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQL Server (e.g., SQL Server Express / LocalDB / full SQL Server)

### 1. Clone the repository

```bash
git clone https://github.com/izumi-dev98/POS.git
cd POS
```

### 2. Configure the database connection

Update the connection string in `POS.API/appsettings.json` (and/or `appsettings.Development.json`) to match your local SQL Server instance:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=DB_NOSH_POS;User ID=YOUR_USER;Password=YOUR_PASSWORD;TrustServerCertificate=True;MultipleActiveResultSets=true;Integrated Security=False;"
  }
}
```

> ⚠️ Avoid committing real credentials. Consider using [user secrets](https://learn.microsoft.com/aspnet/core/security/app-secrets) or environment variables for local development.

### 3. Set up the database

Create a database named `DB_NOSH_POS` (or your configured name) with a `MenuCategories` table containing at least:

| Column         | Type          |
|----------------|---------------|
| `Id`           | int (PK)      |
| `MenuCag_Name` | nvarchar      |
| `MenuCag_Des`  | nvarchar      |
| `IsDelete`     | int           |
| `CreatedAt`    | datetime      |
| `UpdatedAt`    | datetime      |
| `DeletedAt`    | datetime      |

### 4. Run the API

```bash
cd POS.API
dotnet restore
dotnet run
```

The API will start on the address shown in the console (e.g., `http://localhost:5070`). In development mode, Swagger UI is available at `/swagger` for exploring and testing endpoints.

## API Endpoints

| Method | Route                | Description                |
|--------|-----------------------|-----------------------------|
| GET    | `/api/MenuCag`        | Get all menu categories     |
| POST   | `/api/MenuCag`        | Create a new menu category  |
| PUT    | `/api/MenuCag/{id}`   | Update an existing category |
| DELETE | `/api/MenuCag/{id}`   | Delete a menu category      |

## License

No license specified yet.
