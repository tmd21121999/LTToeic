# Architecture Rules

This project follows Clean Architecture with 4 projects. Enforce these layer boundaries strictly.

## Layer Order (dependency direction)

```
UI → Infrastructure → Application → Domain
```

- **Domain** — Entities only. No external dependencies.
- **Application** — Business logic, interfaces, DTOs, AutoMapper profiles. No EF Core, no HTTP.
- **Infrastructure** — EF Core, repositories, SMTP. Implements interfaces from Application.
- **UI** — Blazor Server components, pages. Calls services via interfaces only.

## Rules

- Never reference `DbContext` or EF Core types from the UI layer.
- Never add business logic to Blazor components — it belongs in Application services.
- Never skip the service layer by calling repositories directly from UI.
- New features must place code in the correct layer:
  - Entity → Domain
  - Interface + DTO/ViewModel + Service logic → Application
  - Repository implementation + EF config → Infrastructure
  - Razor component + DI wiring → UI

## Dependency Injection Registration

- Repositories and `IEmailSender` → `Infrastructure/Helper/BuildRepositories.cs`
- Services → `Infrastructure/Helper/BuildServices.cs`
- Both helpers are called from `CoreLTToeic.UI/Program.cs`
