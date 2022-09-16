using System;
using System.Collections.Generic;

namespace LoginWebAPI.Data
{
    public partial class Driver
    {
        public long Id { get; set; }
        public string Driva { get; set; } = null!;
        public long DriverId { get; set; }
        public string DriverPhone { get; set; } = null!;
        public string Plate { get; set; } = null!;
    }
}
