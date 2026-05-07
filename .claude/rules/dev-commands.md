# Dev Commands

## Run the App

```powershell
dotnet run --project CoreLTToeic.UI
```

## Build Solution

```powershell
dotnet build LTToeic.sln
```

## Database Migrations

```powershell
# Add a new migration
dotnet ef migrations add <MigrationName> --project CoreLTToeic.Infrastructure --startup-project CoreLTToeic.UI

# Apply migrations to the database
dotnet ef database update --project CoreLTToeic.Infrastructure --startup-project CoreLTToeic.UI
```

## Notes

- Always run commands from the solution root (`c:\Project\LTToeic`).
- After changing any entity or `AppDbContext`, always create a migration before running the app.
