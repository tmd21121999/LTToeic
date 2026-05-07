# UI & Blazor Rules

## Rendering Model

- All components use **Interactive Server Rendering** (Blazor Server). Do not switch to SSR or WebAssembly without explicit instruction.

## Component Library

- Use **AntDesign** components (`AntDesign` 1.6.1, `AntDesign.Charts` 0.9.0) for all UI elements.
- Import the component namespace globally via `Components/_Imports.razor` — do not add per-file `@using` for AntDesign.

## Routing

- Route segments must be in Vietnamese (e.g., `/admin/quan-li-de-thi`).
- Admin pages live under `Components/Pages/Admin/`.
- Auth pages live under `Components/Pages/Auth/`.

## State & Services

- Inject services via interfaces only (e.g., `@inject IExamService ExamService`).
- Never inject `AppDbContext` or any Infrastructure type into Razor components.

## Local Dev URLs

- HTTPS: `https://localhost:7119`
- HTTP: `http://localhost:5075`

## Layout

- `MainLayout.razor` — sidebar + main content shell
- `NavMenu.razor` — navigation links (keep in Vietnamese)
- `App.razor` loads Bootstrap CSS and AntDesign styles
