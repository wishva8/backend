using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Order_Management.Models
{
    public class TokenDetail
    {
        public static int id;
         
        [Key]
        public int Token_Number { get; set; }

        [Column(TypeName = "nvarchar(5)")]
        public string Order_ID { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Customer_Name { get; set; }

        [Column(TypeName = "nvarchar(12)")]
        public string Tel_No { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Address { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Description { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Pay_Method { get; set; }
    }
}
