using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Order_Management.Models.DTO
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Allergies { get; set; }

        public string Email { get; set; }
       
        public string Telephone { get; set; }

        public string Address { get; set; }

        public string password { get; set; }

        public int Age { get; set; }
    }
}
