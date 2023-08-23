namespace SysMed.Model
{
    public class MaintenanceSchedule
    {
        public int Id { get; set; }
        public int MedicalDeviceId { get; set; }
        public string Description { get; set; }
        public DateTime ScheduledDate { get; set; }
        public DateTime CompletedOn { get; set; }
        public bool Completed { get; set; }
        public string PerformedBy { get; set; }
    }
}