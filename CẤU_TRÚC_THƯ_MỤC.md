# Phân tích cấu trúc thư mục SIMS

## Tổng quan

SIMS là ứng dụng web ASP.NET Core MVC chạy trên .NET 10. Cấu trúc hiện tại tách tương đối rõ phần xử lý request, dữ liệu giao diện và tài nguyên tĩnh.

> Lưu ý: dự án hiện tại đang dùng **MVC với Views**, chưa sử dụng Razor Pages (`Pages/`).

## Cấu trúc chính

```text
SIMS/
├── SIMS.slnx                         # File solution
├── SIMS.csproj                        # Cấu hình dự án, target .NET 10
├── Program.cs                         # Khởi tạo ứng dụng và cấu hình pipeline
├── appsettings.json                   # Cấu hình dùng chung
├── appsettings.Development.json       # Cấu hình môi trường Development
│
├── Controllers/
│   └── HomeController.cs              # Xử lý các action Home, Privacy, Error
│
├── Models/
│   └── ErrorViewModel.cs              # Model phục vụ trang lỗi
│
├── Views/
│   ├── Home/
│   │   ├── Index.cshtml               # Giao diện trang chủ
│   │   └── Privacy.cshtml              # Giao diện trang Privacy
│   ├── Shared/
│   │   ├── _Layout.cshtml             # Layout dùng chung
│   │   ├── _Layout.cshtml.css         # CSS cho layout
│   │   ├── _ValidationScriptsPartial.cshtml
│   │   └── Error.cshtml                # Giao diện trang lỗi
│   ├── _ViewImports.cshtml             # Import dùng chung cho Razor Views
│   └── _ViewStart.cshtml               # Cấu hình khởi tạo View
│
├── wwwroot/
│   ├── css/site.css                    # CSS tùy chỉnh
│   ├── js/site.js                      # JavaScript tùy chỉnh
│   ├── favicon.ico                     # Biểu tượng website
│   └── lib/                            # Thư viện frontend bên thứ ba
│       ├── bootstrap/
│       ├── jquery/
│       ├── jquery-validation/
│       └── jquery-validation-unobtrusive/
│
└── Properties/
	└── launchSettings.json             # Cấu hình chạy local và profile
```

## Luồng hoạt động khái quát

1. `Program.cs` khởi tạo ứng dụng và đăng ký MVC bằng `AddControllersWithViews()`.
2. Request được định tuyến theo mẫu `{controller}/{action}/{id?}`.
3. `HomeController` tiếp nhận request và trả về View tương ứng trong thư mục `Views/Home`.
4. Các View dùng `_Layout.cshtml` trong `Views/Shared` để tạo bố cục chung.
5. CSS, JavaScript và thư viện frontend được phục vụ từ `wwwroot`.

## Nhận xét ngắn

- Cấu trúc phù hợp với ứng dụng ASP.NET Core MVC cơ bản.
- `Controllers`, `Models` và `Views` được phân tách theo mô hình MVC.
- `wwwroot/lib` đang chứa các thư viện frontend được quản lý trực tiếp trong dự án.
- Chưa thấy các thư mục nghiệp vụ như `Data`, `Services` hoặc `Repositories`; có thể bổ sung khi hệ thống phát triển.
