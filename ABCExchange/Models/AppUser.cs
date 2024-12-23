using Microsoft.AspNetCore.Identity;

namespace ABCExchange.Models
{
    public class AppUser : IdentityUser<int>
    {
        public string? FullName { get; set; }
    }
}
