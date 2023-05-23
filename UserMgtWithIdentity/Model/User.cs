﻿using Microsoft.AspNetCore.Identity;

namespace UserMgtWithIdentity.Model
{
    public class ApplicationUser : IdentityUser
    {
        public int Age { get; set; }
        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; } 
        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
        public virtual ICollection<IdentityUserToken<string>> Tokens { get; set; }
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    }   
}
