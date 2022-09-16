using System;
using System.Collections.Generic;

namespace LoginWebAPI.Data
{
    public partial class Fuelsupply
    {
        public long Id { get; set; }
        public string Driva { get; set; } = null!;
        public string Supplier { get; set; } = null!;
        public long SupplierPhone { get; set; }
        public decimal SuppliedLitters { get; set; }
        public DateTime SupplyDate { get; set; }
        public string SupplyTime { get; set; } = null!;
        public int VehicleId { get; set; }
        public string NumberPlate { get; set; } = null!;
        public string FuelType { get; set; } = null!;
    }
}
