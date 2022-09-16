using System;
using System.Collections.Generic;

namespace LoginWebAPI.Data
{
    public partial class Commodity
    {
        public int Id { get; set; }
        public string Materials { get; set; } = null!;
        public double MaterialCost { get; set; }
        public string Matserial { get; set; } = null!;
    }
}
