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

## Convention UI
- Hạn chế dùng css inline và các class mới, ưu tiên dùng component UI đã có sẵn của Ant Design
- Nếu không thể tạo dùng từ component, thì xem có thể dùng tailwind css class hay không, nếu không thể -> dùng css class 
- Hạn chế dùng các tag trực tiếp từ html, ưu tiên dùng component

## Error Handling trong Blazor Components

Mọi hàm `async Task` gọi service hoặc xử lý file đều phải bọc try-catch và hiển thị lỗi qua `MessageService`:

```csharp
// Load dữ liệu (OnInitializedAsync, Open*, OnChanged*)
try
{
    _data = (await SomeService.GetAsync()).ToList();
}
catch (Exception ex) { await Message.ErrorAsync($"Lỗi tải dữ liệu: {ex.Message}"); }
finally { _loading = false; } // chỉ khi có loading flag

// Lưu / Xoá (có loading flag)
_saving = true;
try
{
    await SomeService.SaveAsync(model);
    await Message.SuccessAsync("Lưu thành công");
}
catch (Exception ex) { await Message.ErrorAsync($"Lỗi: {ex.Message}"); }
finally { _saving = false; }

// File upload
try { _field = await SaveUploadedFile(e.File, "folder"); }
catch (Exception ex) { await Message.ErrorAsync($"Lỗi tải file: {ex.Message}"); }
```

Quy tắc:
- Luôn dùng `finally` để reset loading flag (`_loading`, `_saving`, `_savingQ`...) tránh UI bị kẹt.
- Không để exception propagate lên Blazor circuit — sẽ gây crash toàn trang.
- Thông báo lỗi dùng `Message.ErrorAsync(...)`, thành công dùng `Message.SuccessAsync(...)`. 