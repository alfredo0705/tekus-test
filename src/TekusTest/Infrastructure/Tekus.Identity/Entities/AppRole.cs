using Microsoft.AspNetCore.Identity;

namespace Tekus.Identity.Entities
{
    public class AppRole : IdentityRole<int>
    {
        public virtual ICollection<AppUserRole> UserRoles { get; set; } = new List<AppUserRole>();
    }
}
