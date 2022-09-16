using System;
using System.Collections.Generic;

namespace LoginWebAPI.Data
{
    public partial class Weibrideaccount
    {
        public int Id { get; set; }
        public string AccountNo { get; set; } = null!;
        public string Plate { get; set; } = null!;
        public double SpentAmount { get; set; }
        public double Balance { get; set; }
    }
}
