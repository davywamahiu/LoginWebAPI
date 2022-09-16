using System;
using System.Collections.Generic;

namespace LoginWebAPI.Data
{
    public partial class Mysupplier
    {
        public int Id { get; set; }
        public string Plate { get; set; } = null!;
        public string Supplier { get; set; } = null!;
        public string Driver { get; set; } = null!;
        public long SupplierPhone { get; set; }
    }
}
