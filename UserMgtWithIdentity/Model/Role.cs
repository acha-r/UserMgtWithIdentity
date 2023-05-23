using Microsoft.AspNetCore.Identity;

namespace UserMgtWithIdentity.Model
{
    public class ApplicationRole : IdentityRole
    {
        public string Description { get; set; }
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    }

    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }
}
