using System;
using System.Collections.Generic;

namespace LoginWebAPI.Data
{
    public partial class Taska
    {
        public int Id { get; set; }
        public string Activitiz { get; set; } = null!;
        public string TasDependsOn { get; set; } = null!;
        public string TasCompCreteria { get; set; } = null!;
        public DateTime TasStartDate { get; set; }
        public DateTime TasEndDate { get; set; }
        public int ActId { get; set; }
    }
}
