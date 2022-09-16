using System;
using System.Collections.Generic;

namespace LoginWebAPI.Data
{
    public partial class Machinery
    {
        public int Id { get; set; }
        public string Mcondition { get; set; } = null!;
        public string ChasisNo { get; set; } = null!;
        public double Cost { get; set; }
        public string EngineNo { get; set; } = null!;
        public string Logbook { get; set; } = null!;
        public string RegNo { get; set; } = null!;
        public string UsedStatus { get; set; } = null!;
        public string VehiclType { get; set; } = null!;
        public string Yearz { get; set; } = null!;
    }
}
