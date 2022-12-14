using Microsoft.AspNetCore.Identity;

namespace LoginWebAPI.Data
{
    public class Users : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public char Gender { get; set; }
    }
}
