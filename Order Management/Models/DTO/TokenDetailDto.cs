using Order_Management.Models.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_Management.Models.DTO
{
    public class TokenDetailDto
    {

        public int Id { get; set; }

        public int OrderID { get; set; }

        public int CustomerId { get; set; }
        public CustomerDto Customer { get; set; }

        public Status Status { get; set; }

        public bool Urgent { get; set; }

        public string Description { get; set; }

        public PayMethod PayMethod { get; set; }

        public string StringStatus { get; set; }
        public string StringPayMethod { get; set; }
        public string StringUrgent { get; set; }
    }
}
