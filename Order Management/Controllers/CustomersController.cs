using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Order_Management.Models;
using Order_Management.Models.DTO;
using Order_Management.Services.Contracts;

namespace Order_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly DeliveryTokenDB _context;
        private readonly ICustomerService _customerService;

        public CustomersController(DeliveryTokenDB context, ICustomerService customerService)
        {
            _context = context;
            _customerService = customerService;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<List<CustomerDto>> GetCustomers()
        {
            return await _customerService.GetCustomers();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<CustomerDto> GetCustomer(int id)
        {
            return await _customerService.GetCustomer(id);
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<bool> PutCustomer(CustomerDto dto)
        {
            return await _customerService.UpdateCustomer(dto);
        }

        // POST: api/Customers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(CustomerDto customer)
        {
            await _customerService.AddCustomer(customer);
            return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<bool> DeleteCustomer(int id)
        {
            return await _customerService.DeleteCustomer(id);
        }

        // DELETE: api/Customers/Prescription
        [HttpPost("Prescription")]
        public async Task<int> AddPrescription(IFormCollection collection)
        {
            try
            {
                var files = collection.Files;
                foreach (var file in files)
                    await _customerService.AddPrescription(file);
                    return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        [HttpGet("Prescription")]
        public async Task<IActionResult> GetPrescription()
        {
            var images = await _context.Prescription.ToListAsync();
            return Ok(images);
        }

        [HttpPost("Login")]
        public async Task<CustomerDto> Login([FromBody] LoginDto dto)
        {
            var user =await _customerService.Login(dto);
            return user;
        }
    }
}
