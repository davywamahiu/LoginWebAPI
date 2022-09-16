using System;
using System.Collections.Generic;

namespace LoginWebAPI.Data
{
    public partial class Wbsaletb
    {
        public int Id { get; set; }
        public int Ticket { get; set; }
        public double Weight { get; set; }
        public string Driver { get; set; } = null!;
        public long Phone { get; set; }
        public string Plate { get; set; } = null!;
        public double? Deposit { get; set; }
        public double? Balance { get; set; }
        public string? AccountNo { get; set; }
        public string Material { get; set; } = null!;
        public double Amount { get; set; }
        public DateTime DateTime { get; set; }
        public string Time { get; set; } = null!;
        public double? Sweight { get; set; }
    }
}
