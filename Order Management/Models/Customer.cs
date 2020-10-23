
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Order_Management.Models
{
    public class Customer: EntityBase
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Allergies { get; set; }

        public string Email { get; set; }
        [MaxLength(12)]
        public string Telephone { get; set; }

        [MaxLength(50)]
        public string Address { get; set; }

        public int Age { get; set; }

        public string password { get; set; }

        public ICollection<Order> Orders { get; set; }
        public ICollection<Prescription> Prescriptions { get; set; }
    }
}
