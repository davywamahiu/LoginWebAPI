using System;
using System.Collections.Generic;

namespace LoginWebAPI.Data
{
    public partial class Subtaska
    {
        public int Id { get; set; }
        public string SubTaski { get; set; } = null!;
        public string Casuals { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Machines { get; set; } = null!;
        public string Materials { get; set; } = null!;
        public string RdSection { get; set; } = null!;
        public string Trucks { get; set; } = null!;
        public int ActId { get; set; }
    }
}
