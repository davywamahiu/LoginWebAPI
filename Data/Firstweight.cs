using System;
using System.Collections.Generic;

namespace LoginWebAPI.Data
{
    public partial class Firstweight
    {
        public int Id { get; set; }
        public int Ticket { get; set; }
        public double Weight { get; set; }
        public string Driver { get; set; } = null!;
        public long Phone { get; set; }
        public string Plate { get; set; } = null!;
        public string Material { get; set; } = null!;
        public double Amount { get; set; }
        public DateTime DateTime { get; set; }
        public string Time { get; set; } = null!;
    }
}
