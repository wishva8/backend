using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Order_Management.Models;
using Order_Management.Models.DTO;
using Order_Management.Services.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Order_Management.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly DeliveryTokenDB _context;
        private readonly IEmailService _mailService;
        public CustomerService(DeliveryTokenDB context, IEmailService mailService)
        {
            _context = context;
            _mailService = mailService;
        }

        public async Task AddCustomer(CustomerDto customer)
        {
            var cust = new Customer()
            {
                Address = customer.Address,
                Age = customer.Age,
                Allergies = customer.Allergies,
                Email = customer.Email,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                password = customer.password,
                Telephone = customer.Telephone
            };

            await _mailService.SendEmail("sellam@yopmail.com", "Subject", "This is body");

            _context.Customers.Add(cust);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CustomerDto>> GetCustomers()
        {
            var customers = await _context.Customers.Select(
                            c => new CustomerDto()
                            {
                                Id = c.Id,
                                Address = c.Address,
                                Age = c.Age,
                                Allergies = c.Allergies,
                                Email = c.Email,
                                FirstName = c.FirstName,
                                LastName = c.LastName,
                                password = c.password,
                                Telephone = c.Telephone
                            }
                            ).ToListAsync();

            return customers;
        }

        public async Task<CustomerDto> GetCustomer(int id)
        {
            var customer = await _context.Customers.Select(
                        c => new CustomerDto()
                        {
                            Id = c.Id,
                            Address = c.Address,
                            Age = c.Age,
                            Allergies = c.Allergies,
                            Email = c.Email,
                            FirstName = c.FirstName,
                            LastName = c.LastName,
                            password = c.password,
                            Telephone = c.Telephone

                        }).FirstOrDefaultAsync(c => c.Id == id);

            return customer;
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            var customer = await _context.Tokens.FirstOrDefaultAsync(t => t.Id == id);
            if (customer == null)
                return false;


            _context.Tokens.Remove(customer);
            await _context.SaveChangesAsync();
            return true;

        }
        public async Task<bool> UpdateCustomer(CustomerDto dto)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(t => t.Id == dto.Id);
            if (customer == null)
                return false;

            customer.Address = dto.Address;
            customer.Age = dto.Age;
            customer.Allergies = dto.Allergies;
            customer.Email = dto.Email;
            customer.FirstName = dto.FirstName;
            customer.LastName = dto.LastName;
            customer.password = dto.password;
            customer.Telephone = dto.Telephone;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<int> AddPrescription(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {

                var objfiles = new Prescription()
                {
                    CustomerId = 1,
                };

                using (var target = new MemoryStream())
                {
                    file.CopyTo(target);
                    objfiles.Image = target.ToArray();
                }

                _context.Prescription.Add(objfiles);
                await _context.SaveChangesAsync();
                return 1;
            }
            return 0;
        }

        public async Task<List<Prescription>> GetPrescriptions()
        {
            var prescriptions = await _context.Prescription.Select(
                            p => new Prescription()
                            {
                                //MemoryStream ms=new MemoryStream(p.Image),
                                //Image img= Image.FormStream(ms),
                                
                            }
                            ).ToListAsync();

            return prescriptions;

        }

        public async Task<CustomerDto> Login(LoginDto dto)
        {
            var user = await _context.Customers.Where(c => c.Email == dto.Email && c.password == dto.Password).Select(
                            p => new CustomerDto()
                            {
                                Id=p.Id
                            }
                            ).FirstOrDefaultAsync();

            return user;

        }
    }
}
