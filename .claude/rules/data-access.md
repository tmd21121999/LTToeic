# Data Access Rules

## Repository Pattern

- All repositories implement the generic `IRepository<T>` in `Application/Interfaces/Pattern/IRepository.cs` (CRUD, pagination, eager loading).
- Typed repository interfaces (e.g., `IExamRepository`) extend the generic interface and live in `Application/Interfaces/IRepository/`.
- Concrete implementations live in `Infrastructure/Repositories/`.

## DbContext Usage

- Use `IDbContextFactory<AppDbContext>` inside Infrastructure repositories — never inject `AppDbContext` directly (Blazor Server lifetime safety).
- `AppDbContext` inherits `IdentityDbContext<AppUser>`. Add new `DbSet<T>` properties there for new entities.

## Migrations

```powershell
# Add a migration
dotnet ef migrations add <MigrationName> --project CoreLTToeic.Infrastructure --startup-project CoreLTToeic.UI

# Apply to database
dotnet ef database update --project CoreLTToeic.Infrastructure --startup-project CoreLTToeic.UI
```

- Always add a migration after changing any entity or DbContext.
- Migration files live in `CoreLTToeic.Infrastructure/Migrations/`.

## Adding a New Entity

1. Create entity class in `CoreLTToeic.Domain/Entities/`
2. Add `DbSet<T>` to `AppDbContext`
3. Create `I*Repository` interface in `Application/Interfaces/IRepository/`
4. Create repository implementation in `Infrastructure/Repositories/`
5. Register in `Infrastructure/Helper/BuildRepositories.cs`
6. Add migration and update database
