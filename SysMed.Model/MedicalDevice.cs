namespace SysMed.Model
{
    public class MedicalDevice
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public DateTime PurchaseDate { get; set; }

        public DateTime LastMaintenanceDate { get; set; }

        public int MaintenanceIntervalInDays { get; set; }

        public virtual ICollection<Maintenance> MaintenanceSchedules { get; set; }
    }
}