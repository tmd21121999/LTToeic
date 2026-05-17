# LTToeic — Bảng Theo Dõi Chức Năng

> Cập nhật lần cuối: 2026-05-17
> Đánh dấu `[x]` khi hoàn thành, thêm ngày hoàn thành vào cuối dòng.

---

## 1. Xác Thực Người Dùng (Authentication)

| # | Chức năng | Trạng thái | Ghi chú |
|---|-----------|-----------|---------|
| 1.1 | Đăng ký tài khoản (`/register`) | ✅ Hoàn thành | `Register.razor` + `AuthRepository` |
| 1.2 | Đăng nhập (`/login`) | ✅ Hoàn thành | `Login.razor` |
| 1.3 | Xác nhận email (`/confirm`) | ⚠️ Thiếu một phần | UI có, nhưng endpoint `GET /api/auth/confirm` **chưa được tạo** |
| 1.4 | Đăng xuất | ✅ Hoàn thành | Nằm trong `NavMenu.razor` |
| 1.5 | Quên mật khẩu / Đặt lại mật khẩu | ❌ Chưa làm | |
| 1.6 | Đổi mật khẩu | ❌ Chưa làm | |

---

## 2. Hồ Sơ Người Dùng (User Profile)

| # | Chức năng | Trạng thái | Ghi chú |
|---|-----------|-----------|---------|
| 2.1 | Trang hồ sơ cá nhân | ❌ Chưa làm | Entity `AppUser` có đủ field: Avatar, Address, Education, Occupation, EnglishLevel, TargetScore |
| 2.2 | Chỉnh sửa thông tin cá nhân | ❌ Chưa làm | |
| 2.3 | Upload ảnh đại diện | ❌ Chưa làm | |
| 2.4 | Dashboard người dùng (lịch sử thi, tiến độ) | ❌ Chưa làm | |

---

## 3. Đề Thi TOEIC (Tests)

| # | Chức năng | Trạng thái | Ghi chú |
|---|-----------|-----------|---------|
| 3.1 | Danh sách đề thi (`/luyen-thi`) | ✅ Hoàn thành | `TestList.razor` |
| 3.2 | Làm bài thi (`/luyen-thi/{TestId}`) | ✅ Hoàn thành | `TakeTest.razor`, timer, answer sheet |
| 3.3 | Nộp bài & tính điểm tự động | ✅ Hoàn thành | `UserResultService.SubmitTestAsync` |
| 3.4 | Trang kết quả sau khi nộp bài | ❌ Chưa làm | `UserResult` entity có đủ data nhưng chưa có trang hiển thị |
| 3.5 | Xem lại đáp án chi tiết sau thi | ❌ Chưa làm | |
| 3.6 | Lịch sử các lần thi của người dùng | ❌ Chưa làm | `UserResultRepository.GetByUserIdAsync` đã có |
| 3.7 | Chế độ luyện tập từng Part | ❌ Chưa làm | Enum `TestMode.Practice` đã có |
| 3.8 | Chế độ thi thử toàn bài | ✅ Hoàn thành | `TestMode.Simulation` |
| 3.9 | Lọc/tìm kiếm đề thi theo danh mục | ⚠️ Một phần | UI có filter, backend cần kiểm tra |
| 3.10 | Bảng quy đổi điểm Listening/Reading | ⚠️ Thiếu dữ liệu | Entity `ReadingScoreConversion` + `ListeningScoreConversion` có, chưa seed data |

---

## 4. Quản Lý Đề Thi (Admin — Test Management)

| # | Chức năng | Trạng thái | Ghi chú |
|---|-----------|-----------|---------|
| 4.1 | Danh sách đề thi (admin) | ✅ Hoàn thành | `ExamManagementList.razor` `/admin/quan-li-de-thi` |
| 4.2 | Thêm / Sửa / Xoá đề thi | ✅ Hoàn thành | |
| 4.3 | Quản lý Part (Part 1–7) | ✅ Hoàn thành | `TestPartManager.razor` |
| 4.4 | Thêm / Sửa / Xoá câu hỏi đơn | ✅ Hoàn thành | |
| 4.5 | Thêm / Sửa / Xoá nhóm câu hỏi | ✅ Hoàn thành | |
| 4.6 | Upload audio cho câu hỏi | ✅ Hoàn thành | |
| 4.7 | Upload ảnh cho câu hỏi | ✅ Hoàn thành | |
| 4.8 | Preview câu hỏi realtime | ✅ Hoàn thành | `QuestionPreviewCard.razor`, `QuestionGroupPreviewCard.razor` |
| 4.9 | Quản lý danh mục đề thi | ⚠️ Một phần | Service method có, chưa có trang UI riêng |
| 4.10 | Import đề thi từ JSON/file | ⚠️ Có seeder | `ToeicTestSeeder` chỉ dùng để seed, chưa phải UI import |
| 4.11 | Phân quyền admin (bảo vệ route) | ❌ Chưa làm | Route admin chưa có `[Authorize(Roles="Admin")]` |

---

## 5. Khóa Học (Courses)

| # | Chức năng | Trạng thái | Ghi chú |
|---|-----------|-----------|---------|
| 5.1 | Quản lý khóa học (admin) | ✅ Hoàn thành | `CourseManagement.razor` `/admin/quan-li-khoa-hoc` |
| 5.2 | Thêm / Sửa / Xoá khóa học | ✅ Hoàn thành | |
| 5.3 | Quản lý chương học (Section) | ✅ Hoàn thành | |
| 5.4 | Quản lý bài học (Lesson) | ✅ Hoàn thành | |
| 5.5 | Upload thumbnail khóa học | ✅ Hoàn thành | |
| 5.6 | Trang danh sách khóa học (user) | ❌ Chưa làm | NavMenu disabled |
| 5.7 | Trang chi tiết khóa học (user) | ❌ Chưa làm | |
| 5.8 | Đăng ký khóa học | ❌ Chưa làm | Entity `CourseEnrollment` có |
| 5.9 | Xem bài học / video | ❌ Chưa làm | |
| 5.10 | Theo dõi tiến độ học (LessonCompletion) | ❌ Chưa làm | Entity có |
| 5.11 | Quiz trong bài học | ❌ Chưa làm | Entity `QuizQuestion` + `QuizQuestionOption` có |
| 5.12 | Đánh giá / Review khóa học | ❌ Chưa làm | Entity `CourseReview` có |

---

## 6. Tài Liệu (Materials)

| # | Chức năng | Trạng thái | Ghi chú |
|---|-----------|-----------|---------|
| 6.1 | Trang tài liệu luyện thi | ❌ Chưa làm | NavMenu disabled |
| 6.2 | Upload / tải tài liệu PDF | ❌ Chưa làm | |
| 6.3 | Phân loại tài liệu theo Part | ❌ Chưa làm | |

---

## 7. Quản Trị Hệ Thống (Admin)

| # | Chức năng | Trạng thái | Ghi chú |
|---|-----------|-----------|---------|
| 7.1 | Dashboard thống kê (số user, lượt thi...) | ❌ Chưa làm | |
| 7.2 | Quản lý người dùng (danh sách, phân quyền) | ❌ Chưa làm | |
| 7.3 | Xem kết quả thi của tất cả user | ❌ Chưa làm | |
| 7.4 | Quản lý bảng quy đổi điểm | ❌ Chưa làm | Entity `ReadingScoreConversion`, `ListeningScoreConversion` có |
| 7.5 | Phân quyền bảo vệ tất cả route `/admin/*` | ❌ Chưa làm | |

---

## 8. Hạ Tầng & Kỹ Thuật

| # | Chức năng | Trạng thái | Ghi chú |
|---|-----------|-----------|---------|
| 8.1 | Clean Architecture 4 layers | ✅ Hoàn thành | |
| 8.2 | ASP.NET Core Identity | ✅ Hoàn thành | |
| 8.3 | EF Core + SQL Server | ✅ Hoàn thành | |
| 8.4 | AutoMapper profiles | ✅ Hoàn thành | |
| 8.5 | Email xác nhận (SMTP Gmail) | ✅ Hoàn thành | |
| 8.6 | Endpoint `GET /api/auth/confirm` | ❌ Chưa làm | Controller thiếu — xem `auth.md` |
| 8.7 | Seed data bảng quy đổi điểm | ❌ Chưa làm | |

---

## Tóm Tắt Nhanh

| Layer | Đã làm | Chưa làm |
|-------|--------|----------|
| Authentication | Đăng ký, đăng nhập, đăng xuất | Quên MK, xác nhận email API, đổi MK |
| Test | Làm bài, nộp bài, admin CRUD | Kết quả sau thi, lịch sử, luyện Part riêng |
| Course | Admin CRUD đầy đủ | Toàn bộ UI phía user |
| User Profile | — | Hồ sơ, dashboard, ảnh đại diện |
| Admin | Quản lý đề thi, khóa học | Dashboard, user management, phân quyền |
| Tài liệu | — | Toàn bộ |

---

## Log Cập Nhật

| Ngày | Chức năng hoàn thành |
|------|---------------------|
| 2026-05-17 | Khởi tạo file tracking, khảo sát toàn bộ codebase |
