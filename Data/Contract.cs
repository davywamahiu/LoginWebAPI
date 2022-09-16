using System;
using System.Collections.Generic;

namespace LoginWebAPI.Data
{
    public partial class Contract
    {
        public int Id { get; set; }
        public string Client { get; set; } = null!;
        public double Cost { get; set; }
        public double Distance { get; set; }
        public string Engineer { get; set; } = null!;
        public DateTime ExpectedD { get; set; }
        public string ProjectName { get; set; } = null!;
        public string ProjectType { get; set; } = null!;
        public string Resident { get; set; } = null!;
        public DateTime RevisedD { get; set; }
        public string Road { get; set; } = null!;
        public DateTime SignedOn { get; set; }
        public DateTime StartD { get; set; }
        public string Surveyor { get; set; } = null!;
    }
}
