using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_Management.Models
{
    public class OrderItem : EntityBase
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public int Total { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
