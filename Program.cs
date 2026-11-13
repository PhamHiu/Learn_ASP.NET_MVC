using System.Runtime.Intrinsics.X86;
using SIMS.SimsDB; // khai báo SimsDB để dùng 
using Microsoft.EntityFrameworkCore;
using SIMS.Interfaces;
using SIMS.Services;
using SIMS.Repositories;
namespace SIMS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



            // B5 config conection to Database of SIMS --------------------------------------------------------
            builder.Services.AddDbContext<SimsDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSqlServer")));
            //  cấu hình trong file appsettings.json -- cấu hình connectionString );
            // B1 : tiến hành khai báo BD trong thư mục (Folder SimDB)
            // B2 : tạo class SimsDbContext: DbContext của EntityFrameworkCore và khái báotoàn bộ các bảng và các cột kèm ràng buộc của từng cột và relationship     
            // B3 : tạo constructor để truyền các options 
            // B4 : cấu hình trong file appsettings.json -- cấu hình connectionString
            // b5 : cấu hình taij program.cs để tiến hành link giữa file appsettings.json và class SimsDbContext để tiến hành kết nối với database 






            //sau khi triển khai kế thừa xong thì phải tiến hành đăng kí các interface để tiến hành link các interface với nhau thì mới hoạt động được 
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();

























            // Add services to the container.
            //đăng kí mvc và api controller để tiến hành chạy web
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                // điều chỉnh thuộc tính controller=home => controller = Test thì khi chạy web sẽ hiện trang test(file/class: TestController) và chạy thẳng hàm demo 
                // controller=...      controller được chạy đầu tiên 
                // action=...          hàm được chạy đầu tiên 
                pattern: "{controller=Login}/{action=index}/{id?}")
                //pattern: "{controller=Demo}/{action=Product}/{id?}")
                .WithStaticAssets();


            // đăng kí dùng api 
            app.MapControllers();

            app.Run();
        }
    }
}
