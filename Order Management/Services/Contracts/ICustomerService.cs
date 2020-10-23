using Microsoft.AspNetCore.Http;
using Order_Management.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_Management.Services.Contracts
{
    public interface ICustomerService
    {
        Task AddCustomer(CustomerDto customer);
        Task<int> AddPrescription(IFormFile file);

        Task<List<CustomerDto>> GetCustomers();

        Task<CustomerDto> GetCustomer(int id);

        Task<bool> DeleteCustomer(int id);

        Task<bool> UpdateCustomer(CustomerDto dto);
        Task<CustomerDto> Login(LoginDto dto);

    }
}
