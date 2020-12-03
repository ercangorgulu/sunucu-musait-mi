using Microsoft.EntityFrameworkCore;
using SunucuMusaitMi.Domain;

namespace SunucuMusaitMi.Persistance
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ServerAvailability> ServerAvailability { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ServerAvailability>().ToTable("ServerAvailability");
        }
    }
}