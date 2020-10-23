using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_Management.Models.DTO
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int Total { get; set; }
        public List<OrderItemDto> Products { get; set; }
        public CustomerDto Customer { get; set; }
    }
}
