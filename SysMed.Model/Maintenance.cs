using System;

namespace SysMed.Model
{
    public class Maintenance
    {
        public int Id { get; set; }
        public int MedicalDeviceId { get; set; }
        public MaintenanceType Type { get; set; }
        public string Description { get; set; }
        public DateTime ScheduledDate { get; set; }
        public DateTime CompletedOn { get; set; }
        public bool Completed { get; set; }
        public string PerformedBy { get; set; }
        public virtual MedicalDevice MedicalDevice { get; set; }
    }
}