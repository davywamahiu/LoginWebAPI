using System;
using System.Collections.Generic;

namespace LoginWebAPI.Data
{
    public partial class Casual
    {
        public int Id { get; set; }
        public string Epin { get; set; } = null!;
        public string Estatus { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string MiddleName { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Supervisor { get; set; } = null!;
        public long Phone { get; set; }
        public string Wages { get; set; } = null!;
        public string Department { get; set; } = null!;
        public string OvertimeRates { get; set; } = null!;
        public long NatId { get; set; }
    }
}
