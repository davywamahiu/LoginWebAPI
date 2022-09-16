using System;
using System.Collections.Generic;

namespace LoginWebAPI.Data
{
    public partial class Fleetassigned
    {
        public int Id { get; set; }
        public string Assigneed { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string Epin { get; set; } = null!;
        public string Plate { get; set; } = null!;
        public string Projectz { get; set; } = null!;
        public string Statuss { get; set; } = null!;
        public double NatId { get; set; }
    }
}
