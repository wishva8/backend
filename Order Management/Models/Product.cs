using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Order_Management.Models
{
    public class Product : EntityBase
    {
        [MaxLength(30)]
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public int Price { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
