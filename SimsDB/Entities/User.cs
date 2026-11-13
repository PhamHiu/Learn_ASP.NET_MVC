namespace SIMS.SimsDB.Entities
{
    public class User
    {
        // nơi định nghĩa các thuộc tính của bảng Users của DB => phục vụ cho ánh xạ ORM\
        // mỗi bảng sẽ tạo riêng 1 class , mỗi cột 1 thuộc tính
        // tên biến phải trùng với tên các cột trong bảng Users của DB
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string Role { get; set; } = "student";
        public byte Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        // dấu ? là cho phép null 
        // trong cshap k có tinyint nên dùng byte để thay thế
        //  = "student" là giá trị mặc định khi khỏi tạo đối tượng 

    }
}
