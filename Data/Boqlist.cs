using System;
using System.Collections.Generic;

namespace LoginWebAPI.Data
{
    public partial class Boqlist
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public string MatSerial { get; set; } = null!;
        public string Uniti { get; set; } = null!;
        public double Rati { get; set; }
        public string Projectz { get; set; } = null!;
    }
}
