using Microsoft.AspNetCore.Identity;

namespace GurventVantilator.Domain.Identity
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool IsActive { get; set; } = true;

    }
}
