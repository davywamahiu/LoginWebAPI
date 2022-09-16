using MessagePack;

using System.ComponentModel.DataAnnotations;

using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace LoginWebAPI.Data
{
    public class SysLogin
    {
        
        public long UserId { get; set; }
        public string? Name { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool? IsAdmin { get; set; }
        public DateTime? LastLogin { get; set; }
        public byte [] PasswordHash { get; set; } = null!;
        public byte [] PasswordSalt { get; set; } = null!;
        public long? Phone { get; set; }
        public string? Role { get; set; }
        [Key]
        public string Username { get; set; } = null!;
    }
    public class LoginUser
    {
        public string? Name { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool? IsAdmin { get; set; }
        public DateTime? LastLogin { get; set; }
        public string Password { get; set; } = null!;
        public string? Role { get; set; }
        public long? Phone { get; set; }
        public string Username1 { get; set; } = null!;
    }
}
