using DLL.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DLL.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Route> Routes { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            base.OnModelCreating(builder);
            
            builder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = BLL.DTO.UserRoles.Admin,
                NormalizedName = BLL.DTO.UserRoles.Admin.ToUpper()
            },
            new IdentityRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = BLL.DTO.UserRoles.Moderator,
                NormalizedName = BLL.DTO.UserRoles.Moderator.ToUpper()
            },
            new IdentityRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = BLL.DTO.UserRoles.User,
                NormalizedName = BLL.DTO.UserRoles.User.ToUpper()
            }
            );
        }
    }
}
