using Microsoft.AspNetCore.Identity;

namespace ABCExchange.Models
{
        public class AppRole : IdentityRole<int> { }
        public class AppUserRole : IdentityUserRole<int> { }
        public class AppUserClaim : IdentityUserClaim<int> { }
        public class AppUserLogin : IdentityUserLogin<int> { }
        public class AppUserToken : IdentityUserToken<int> { }
        public class AppRoleClaim : IdentityRoleClaim<int> { }
}
