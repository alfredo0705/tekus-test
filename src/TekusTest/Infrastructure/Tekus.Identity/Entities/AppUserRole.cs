﻿
using Microsoft.AspNetCore.Identity;

namespace Tekus.Identity.Entities
{
    public class AppUserRole : IdentityUserRole<int>
    {
        public virtual AppUser User { get; set; } = null!;
        public virtual AppRole Role { get; set; } = null!;
    }
}