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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicalDevice>().ToTable("MedicalDevices");
            modelBuilder.Entity<Maintenance>().ToTable("Maintenances");
        }
    }
}
