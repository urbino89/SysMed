using Microsoft.EntityFrameworkCore;
using SysMed.Model;

namespace SysMed.Data
{
    public class SysmedContext : DbContext
    {
        public SysmedContext(DbContextOptions<SysmedContext> options) : base(options)
        {
        }

        public DbSet<MedicalDevice> MedicalDevices { get; set; }
        public DbSet<Maintenance> Maintenances { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\\mssqllocaldb;Database=SysMed;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicalDevice>().ToTable("MedicalDevices");
            modelBuilder.Entity<Maintenance>().ToTable("Maintenances");

            // Configuration using Fluent API
            modelBuilder.Entity<MedicalDevice>()
                .Property(p => p.Name)
                .HasMaxLength(250)
                .IsRequired();
            modelBuilder.Entity<MedicalDevice>()
                .Property(p => p.Brand)
                .HasMaxLength(250)
                .IsRequired();
            modelBuilder.Entity<MedicalDevice>()
                .Property(p => p.Model)
                .HasMaxLength(250)
                .IsRequired();
        }
    }
}
