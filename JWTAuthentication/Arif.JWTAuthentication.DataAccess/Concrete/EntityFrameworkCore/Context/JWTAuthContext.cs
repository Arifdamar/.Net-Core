using Arif.JWTAuthentication.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Arif.JWTAuthentication.DataAccess.Concrete.EntityFrameworkCore.Context
{
    public class JWTAuthContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\ProjectsV13; database=JWTAuth; user id=sa; password=1;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration()
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUserRole> AppUserRoles { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
