using Microsoft.EntityFrameworkCore;
using Order_Management.Models;
using Order_Management.Models.DTO;
using Order_Management.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_Management.Services
{
    public class TokenDetailService : ITokenDetailService
    {
        public readonly DeliveryTokenDB _context;

        public TokenDetailService(DeliveryTokenDB context)
        {
            _context = context;
        }

        public async Task<List<TokenDetailDto>> GetTokenDetails()
        {
            var tokens = await _context.Tokens.Select(
                        t => new TokenDetailDto()
                        {
                            Id = t.Id,
                            OrderID = t.OrderId,
                            Status = t.Status,
                            Description = t.Description,
                            PayMethod = t.PayMethod,
                            Urgent = t.Urgent,
                            StringPayMethod = t.PayMethod.ToString(),
                            StringStatus = t.Status.ToString(),
                            StringUrgent = t.Urgent.ToString(),
                            Customer = new CustomerDto()
                            {
                                Id = t.Order.CustomerId,
                                Address = t.Order.Customer.Address,
                                FirstName = t.Order.Customer.FirstName,
                                LastName = t.Order.Customer.LastName,
                                Telephone = t.Order.Customer.Telephone,
                                Email = t.Order.Customer.Email
                            }
                        }).ToListAsync();
            return tokens;
        }

        public async Task AddToken(TokenDetailDto dto)
        {
            var token = new Token()
            {
                OrderId = dto.OrderID,
                Status = dto.Status,
                Description = dto.Description,
                PayMethod = dto.PayMethod,
                Urgent = dto.Urgent

            };
            _context.Tokens.Add(token);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateToken(TokenDetailDto dto)
        {
            var token = await _context.Tokens.FirstOrDefaultAsync(t => t.Id == dto.Id);
            if (token == null)
                return false;

            token.Status = dto.Status;
            token.Description = dto.Description;
            token.PayMethod = dto.PayMethod;
            token.Urgent = dto.Urgent;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<TokenDetailDto> GetToken(int id)
        {
            var token = await _context.Tokens.Select(
                       t => new TokenDetailDto()
                       {
                           Id = t.Id,
                           OrderID = t.OrderId,
                           Status = t.Status,
                           Description = t.Description,
                           PayMethod = t.PayMethod,
                           Urgent = t.Urgent,
                           StringPayMethod = t.PayMethod.ToString(),
                           StringStatus = t.Status.ToString(),
                           Customer = new CustomerDto()
                           {
                               Id = t.Order.CustomerId,
                               Address = t.Order.Customer.Address,
                               FirstName = t.Order.Customer.FirstName,
                               Telephone = t.Order.Customer.Telephone
                           }
                       }).FirstOrDefaultAsync(t => t.Id == id);
            return token;
        }

        public async Task<bool> DeleteToken(int id)
        {
            var token = await _context.Tokens.FirstOrDefaultAsync(t => t.Id == id);
            if (token == null)
                return false;

            _context.Tokens.Remove(token);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<StatisticsDto> GetStatistics()
        {
            var prescriptionCount = await _context.Prescription.CountAsync();
            var customerCount = await _context.Customers.CountAsync();
            var orderCount = await _context.Orders.CountAsync();

            var stat = new StatisticsDto()
            {
                CustomerCount = customerCount,
                OrderCount = orderCount,
                PrescriptionCount = prescriptionCount
            };

            return stat;
        }
    }
}
