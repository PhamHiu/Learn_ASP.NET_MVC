namespace SIMS.DTOs
{
    // DTO trả về thông tin user (loại bỏ trường Password để đảm bảo bảo mật)
    public class UserResponseDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string Role { get; set; } = string.Empty;
        public byte Status { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}

