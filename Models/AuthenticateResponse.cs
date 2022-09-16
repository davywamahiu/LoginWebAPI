using LoginWebAPI.Data;

namespace LoginWebAPI.Models
{
    public class AuthenticateResponse
    {
        public string? Token { get; set; }
        public SysLogin? UserDetail { get; set; }
    }
}
