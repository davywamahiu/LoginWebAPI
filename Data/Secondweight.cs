using System;
using System.Collections.Generic;

namespace LoginWebAPI.Data
{
    public partial class Secondweight
    {
        public int Id { get; set; }
        public double Sweight { get; set; }
        public int Ticket { get; set; }
        public int FirstWeightCode { get; set; }
    }
}
