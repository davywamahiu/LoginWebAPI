using System;
using System.Collections.Generic;

namespace LoginWebAPI.Data
{
    public partial class Activitiza
    {
        public int Id { get; set; }
        public string ActCompCreteria { get; set; } = null!;
        public string ActDependsOn { get; set; } = null!;
        public string? ActName { get; set; }
        public DateTime ActStartDate { get; set; }
        public DateTime ActEndDate { get; set; }
        public string? MyActivitiz { get; set; }
        public string ProjectName { get; set; } = null!;
    }
}
