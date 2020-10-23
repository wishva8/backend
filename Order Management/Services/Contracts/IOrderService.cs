using Order_Management.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_Management.Services.Contracts
{
    public interface IOrderService
    {
        Task AddOrder(OrderDto order);
     //   Task AddProduct(ProductDto product);
        Task<List<OrderDto>> GetOrders();
    }
}
