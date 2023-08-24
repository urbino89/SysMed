using System;

namespace SysMed.Model
{
    public class MedicalDeviceDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public DateTime PurchaseDate { get; set; }

        public DateTime? LastMaintenanceDate { get; set; }

        public int MaintenanceIntervalInDays { get; set; }
    }
}
