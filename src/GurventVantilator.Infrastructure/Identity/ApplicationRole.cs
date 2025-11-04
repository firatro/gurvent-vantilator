using Microsoft.AspNetCore.Identity;

namespace GurventVantilator.Domain.Identity
{
    public class ApplicationRole : IdentityRole<int>
    {
        public ApplicationRole() : base() { }
        public ApplicationRole(string roleName) : base(roleName) { }
    }
}
