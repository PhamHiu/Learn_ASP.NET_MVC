using Microsoft.EntityFrameworkCore;
using SIMS.SimsDB.Entities;// khai báo các class entities tạo trong folder entities 

namespace SIMS.SimsDB
{
    public class SimsDbContext : DbContext
    {
        //B1: tạo class SimsDbContext
        //B2: kế thừa DbContext của EntityFrameworkCore để tạo ra 1 context quản lý các bảng trong DB
        //B3: tạo constructor để truyền các options của DbContext vào
        public SimsDbContext(DbContextOptions<SimsDbContext> options) : base(options) { }


        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //// viết kiểu tường minh 
            //modelBuilder.Entity<User>().ToTable("Users"); // khai báo bảng Users 

            //modelBuilder.Entity<User>().HasKey("Id"); //khóa chính là cột Id
            //modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique(); // cột username là duy nhất
            //modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique(); // cột email là duy nhất\
            //modelBuilder.Entity<User>().Property(u => u.Role).HasDefaultValue("student"); // giá trị mặc định của cột role là student
            //modelBuilder.Entity<User>().Property(u => u.Status).HasDefaultValue(0); // giá trị mặc định của cột status là 0
            //modelBuilder.Entity<User>().Property(u => u.Email).HasMaxLength(100);
            //modelBuilder.Entity<User>().Property(u => u.CreatedAt).HasDefaultValueSql("GETDATE()"); // giá trị mặc định của cột CreatedAt là ngày hiện tại
            //modelBuilder.Entity<User>().Property(u => u.UpdatedAt).HasDefaultValueSql("GETDATE()"); // giá trị mặc định của cột UpdatedAt là ngày hiện tại



            // khai báo nhanh clean 
            //Cấu hình ánh xạ giữa class User và bảng Users trong cơ sở dữ liệu

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users"); // Tên bảng trong cơ sở dữ liệu

                entity.HasKey(u => u.Id); // Khóa chính

                entity.HasIndex(u => u.Username)
                    .IsUnique();


                entity.HasIndex(u => u.Email)
                    .IsUnique();

                entity.Property(u => u.Password)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(u => u.Phone)
                    .HasMaxLength(20);
                entity.Property(u => u.Address)
                    .HasMaxLength(200);
                entity.Property(u => u.Role)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasDefaultValue("student");
                entity.Property(u => u.Status)
                    .IsRequired();
                entity.Property(u => u.CreatedAt)
                    .HasDefaultValueSql("GETDATE()");
                entity.Property(u => u.UpdatedAt)
                    .HasDefaultValueSql("GETDATE()");
            });
        }
    }
}
