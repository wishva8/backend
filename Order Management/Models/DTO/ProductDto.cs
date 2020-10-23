using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Order_Management.Models.DTO
{
    public class ProductDto
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Decription { get; set; }
    }
}
