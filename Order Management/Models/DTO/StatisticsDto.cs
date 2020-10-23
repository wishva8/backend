using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_Management.Models.DTO
{
    public class StatisticsDto
    {
        public int PrescriptionCount { get; set; }
        public int CustomerCount { get; set; }
        public int OrderCount { get; set; }

    }
}
