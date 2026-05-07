# LTToeic Project

**LTToeic** là nền tảng luyện thi TOEIC xây dựng bằng ASP.NET Core Blazor Server (.NET 8), giao diện tiếng Việt, theo kiến trúc **Clean Architecture**.

## Solution Structure

```
LTToeic.sln
├── CoreLTToeic.Domain          # Entities, không phụ thuộc bên ngoài
├── CoreLTToeic.Application     # Business logic, interfaces, DTOs, AutoMapper
├── CoreLTToeic.Infrastructure  # EF Core, repositories, SMTP email
└── CoreLTToeic.UI              # Blazor Server, Ant Design, tầng trình bày
```

## Tech Stack

| Thành phần | Công nghệ |
|---|---|
| Framework | .NET 8.0, ASP.NET Core 8.0 |
| UI | Blazor Server (Interactive Server Rendering) |
| UI Components | AntDesign 1.6.1, AntDesign.Charts 0.9.0 |
| ORM | Entity Framework Core 8.0.26 |
| Database | SQL Server |
| Auth | ASP.NET Core Identity (email confirmation bắt buộc) |
| Mapping | AutoMapper 16.1.1 |
| Email | SMTP (Gmail, port 587, SSL) |

## Rules

Detailed rules are in `.claude/rules/`:

- [architecture.md](rules/architecture.md) — Layer boundaries, DI registration, what goes where
- [conventions.md](rules/conventions.md) — Vietnamese UI, async, AutoMapper, naming
- [data-access.md](rules/data-access.md) — Repository pattern, DbContext, migrations
- [ui-blazor.md](rules/ui-blazor.md) — Blazor Server, AntDesign, routing, component guidelines
- [auth.md](rules/auth.md) — Identity, email confirmation flow, SMTP config, known gaps
- [dev-commands.md](rules/dev-commands.md) — dotnet CLI commands for run/build/migrate
