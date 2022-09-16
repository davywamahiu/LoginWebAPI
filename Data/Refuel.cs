using System;
using System.Collections.Generic;

namespace LoginWebAPI.Data
{
    public partial class Refuel
    {
        public int Id { get; set; }
        public double PrevMilage { get; set; }
        public double Milage { get; set; }
        public decimal RefueliedLitters { get; set; }
        public string Refuelier { get; set; } = null!;
        public string Driver { get; set; } = null!;
        public DateTime RefuelDate { get; set; }
        public string RefuelTime { get; set; } = null!;
        public int VehicleId { get; set; }
        public string NumberPlate { get; set; } = null!;
        public string FuelType { get; set; } = null!;
    }
}
