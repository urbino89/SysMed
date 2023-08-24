using Microsoft.EntityFrameworkCore;
using SysMed.Model;

namespace SysMed.Data
{
    public class SysmedContext : DbContext
    {
        public SysmedContext(DbContextOptions<SysmedContext> options) : base(options)
        {
        }

        public SysmedContext()
        {            
        }

        public DbSet<MedicalDevice> MedicalDevices { get; set; }
        public DbSet<Maintenance> Maintenances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure default schema
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity<MedicalDevice>().ToTable("MedicalDevices");
            modelBuilder.Entity<Maintenance>().ToTable("Maintenances");

            // Configuration using Fluent API
            // MedicalDevice
            modelBuilder.Entity<MedicalDevice>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
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

            // Maintenance
            modelBuilder.Entity<Maintenance>()
               .Property(p => p.Id)
               .ValueGeneratedOnAdd();
        }
    }
}
