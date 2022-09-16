using System;
using System.Collections.Generic;

namespace LoginWebAPI.Data
{
    public partial class Weighbridgesale
    {
        public int Id { get; set; }
        public string Driva { get; set; } = null!;
        public long Phone { get; set; }
        public string Plate { get; set; } = null!;
        public string Material { get; set; } = null!;
        public double TonageRate { get; set; }
        public int Ticket { get; set; }
        public DateTime DateTime { get; set; }
        public double GrossWeight { get; set; }
        public double Tonage { get; set; }
        public double TotalAmount { get; set; }
        public double InBank { get; set; }
        public double TareWeight { get; set; }
        public double Balance { get; set; }
    }
}
