using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginWebAPI.Data
{
    public class Reports
    {
        public int ReportsId { get; set; }
        public string Cod { get; set; } = null!;
        public string Fname { get;set;} = null!;
        public string Repor { get; set; } = null!;
    }
}
