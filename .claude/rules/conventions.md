# Coding Conventions

## Language

- All UI text, labels, route segments, and error messages must be in **Vietnamese**.
- Error/success messages: use constants from `CoreLTToeic.Application/Common/Constants/MessageConstants.cs`. Add new constants there rather than inline strings.

## Async

- Use `async`/`await` consistently across all layers — no `.Result` or `.Wait()`.

## Mapping

- Use **AutoMapper** for all Entity ↔ ViewModel and Entity ↔ EditModel conversions.
- Register mappings in `CoreLTToeic.Application/Mapping/MappingProfile.cs`.
- Never write manual property-by-property mapping between entities and DTOs.

## Data Access

- Always access data through `IRepository<T>` or a typed repository interface — never inject or use `AppDbContext` directly outside Infrastructure.
- In Infrastructure, use `IDbContextFactory<AppDbContext>` — never inject `AppDbContext` directly into repositories.

## Naming

- ViewModels (read): `*ViewModel.cs` in `Application/Models/ViewModels/`
- EditModels (form input): `*EditModel.cs` in `Application/Models/EditModels/`
- Repository interfaces: `I*Repository.cs` in `Application/Interfaces/IRepository/`
- Service interfaces: `I*Service.cs` in `Application/Interfaces/IService/`
