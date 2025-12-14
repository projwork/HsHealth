using Microsoft.EntityFrameworkCore;
using PatientMenu.Api.Models;

namespace PatientMenu.Api.Data
{
    public class MenuDbContext : DbContext
    {
        public MenuDbContext(DbContextOptions<MenuDbContext> options) : base(options) { }

        public DbSet<MenuItem> MenuItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuItem>().HasKey(m => m.Id);
            modelBuilder.Entity<MenuItem>().Property(m => m.Name).IsRequired();
            modelBuilder.Entity<MenuItem>().Property(m => m.TenantId).IsRequired();
        }
    }
}
