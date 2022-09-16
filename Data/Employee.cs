using System;
using System.Collections.Generic;

namespace LoginWebAPI.Data
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string Country { get; set; } = null!;
        public string County { get; set; } = null!;
        public string SubCounty { get; set; } = null!;
        public string Village { get; set; } = null!;
        public string Epin { get; set; } = null!;
        public string? Estatus { get; set; }
        public string FirstName { get; set; } = null!;
        public string MiddleName { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Supervisor { get; set; } = null!;
        public string Role { get; set; } = null!;
        public long Phone { get; set; }
        public string Krapin { get; set; } = null!;
        public string Profession { get; set; } = null!;
        public long Salary { get; set; }
        public long NatId { get; set; }
    }
}
