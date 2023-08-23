using Microsoft.EntityFrameworkCore;
using SysMed.Model;

namespace SysMed.Data
{
    public class SysmedDbContext : DbContext
    {
        public SysmedDbContext(DbContextOptions<SysmedDbContext> options) : base(options)
        {
        }

        public DbSet<MedicalDevice> MedicalDevices { get; set; }
        public DbSet<MaintenanceSchedule> MaintenanceSchedules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicalDevice>().ToTable("MedicalDevices");
            modelBuilder.Entity<MaintenanceSchedule>().ToTable("MaintenanceSchedules");
        }
    }
}
