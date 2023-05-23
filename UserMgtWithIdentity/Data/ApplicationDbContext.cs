using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using UserMgtWithIdentity.Model;

namespace UserMgtWithIdentity.Data
{
    public class ApplicationDbContext : IdentityDbContext
        <ApplicationUser, ApplicationRole, string,
        IdentityUserClaim<string>, ApplicationUserRole, IdentityUserLogin<string>,
        IdentityRoleClaim<string>, IdentityUserToken<string>>
    
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>(u =>
            {
                u.HasMany(u => u.Claims)
                .WithOne()
                .HasForeignKey(uc => uc.UserId)
                .IsRequired();

                u.HasMany(s => s.Logins)
                .WithOne()
                .HasForeignKey(us => us.UserId)
                .IsRequired();

                u.HasMany(e => e.Tokens)
                .WithOne()
                .HasForeignKey(use => use.UserId)
                .IsRequired();

                u.HasMany(r => r.UserRoles)
                .WithOne(r => r.User)
                .HasForeignKey(user => user.UserId)
                .IsRequired();
            });

            builder.Entity<ApplicationRole>(r =>
            {
                r.HasMany(r => r.UserRoles)
                .WithOne(r => r.Role)
                .HasForeignKey(role => role.RoleId)
                .IsRequired();
            });

        }

    }
}