using Microsoft.EntityFrameworkCore;
using Order_Management.Models;
using Order_Management.Models.DTO;
using Order_Management.Services.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_Management.Services
{
    public class OrderService : IOrderService
    {
        private readonly DeliveryTokenDB _context;
        public OrderService(DeliveryTokenDB context)
        {
            _context = context;
        }

        public async Task AddOrder(OrderDto order)
        {
            var newOrder = new Order()
            {
                Total = order.Total,
                CustomerId = order.CustomerId
            };

            var orderItems = new List<OrderItem>();
            foreach (var product in order.Products)
            {
                var orderItem = new OrderItem()
                {
                    ProductId = product.ProductId,
                    Quantity = product.Quantity,
                    Total = product.Total
                };
                orderItems.Add(orderItem);
            }
            newOrder.OrderItems = orderItems;

            _context.Orders.Add(newOrder);
            await _context.SaveChangesAsync();
        }

        public async Task<List<OrderDto>> GetOrders()
        {
            var orders = await _context.Orders.Select(
                        o => new OrderDto()
                        {
                            Id = o.Id,
                            Customer = new CustomerDto()
                            {
                                FirstName = o.Customer.FirstName,
                                LastName=o.Customer.LastName,
                                Address=o.Customer.Address,
                                Telephone=o.Customer.Telephone
                            }
                        }).ToListAsync();

            return orders;

        }
    }
}
