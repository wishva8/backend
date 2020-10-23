using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_Management.Models
{
    public class Order : EntityBase
    {

        public int CustomerId { get; set; }
        public int Total { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Token Token { get; set; }
    }
}
