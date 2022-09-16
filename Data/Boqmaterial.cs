using System;
using System.Collections.Generic;

namespace LoginWebAPI.Data
{
    public partial class Boqmaterial
    {
        public int Id { get; set; }
        public string Material { get; set; } = null!;
        public string MatSerial { get; set; } = null!;
        public double Quantity { get; set; }
        public double Rati { get; set; }
        public string Uniti { get; set; } = null!;
        public double Amount { get; set; }
    }
}
