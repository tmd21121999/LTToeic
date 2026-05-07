# Authentication Rules

## Stack

- ASP.NET Core Identity with `AppUser : IdentityUser` (extra fields: `FullName`, `CreateTime`, `LastLogin`, `DateOfBirth`).
- Email confirmation is **required** before login is allowed.

## Registration & Confirmation Flow

1. User registers at `/register` → `AuthRepository.Register()` creates user and sends confirmation email.
2. Email contains a link to `/confirm?userId=...&token=...`.
3. `Confirm.razor` calls `GET /api/auth/confirm` with the token to complete verification.
4. User logs in at `/login` only after email is confirmed.

## Auth Repository

- `IAuthRepository` in `Application/Interfaces/IRepository/` — methods: `Login`, `Register`, `ConfirmEmail`.
- Implementation in `Infrastructure/Repositories/AuthRepository.cs` — uses `UserManager<AppUser>` and `RoleManager`.

## Email (SMTP)

- Configured under the `Smtp` key in `appsettings.Development.json`:
  - Host: `smtp.gmail.com`, Port: `587`, SSL: `true`
- Config class: `Infrastructure/Config/MailSettings.cs`
- Sender implementation: `Infrastructure/Repositories/SmtpEmailSender.cs` (implements `IEmailSender`)

## Known Gaps

- `/api/auth/confirm` endpoint is not yet implemented — `Confirm.razor` references it but the controller is missing.
- Admin role authorization is not yet enforced on admin routes.
