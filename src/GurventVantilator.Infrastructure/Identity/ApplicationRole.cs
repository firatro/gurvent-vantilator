using Microsoft.AspNetCore.Identity;

namespace GurventVantilator.Infrastructure.Identity
{
    public class ApplicationRole : IdentityRole<int>
    {
        public string? Description { get; set; }
    }
}
