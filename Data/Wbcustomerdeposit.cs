using System;
using System.Collections.Generic;

namespace LoginWebAPI.Data
{
    public partial class Wbcustomerdeposit
    {
        public int Id { get; set; }
        public string Driva { get; set; } = null!;
        public long Phone { get; set; }
        public string Plate { get; set; } = null!;
        public string AccountNo { get; set; } = null!;
        public string MpesaUid { get; set; } = null!;
        public double Deposit { get; set; }
        public double SpentAmount { get; set; }
        public double Balance { get; set; }
        public string? Material { get; set; }
        public double? Tonage { get; set; }
        public string PaidOn { get; set; } = null!;
    }
}
