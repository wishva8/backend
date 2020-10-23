using Order_Management.Models.Common.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace Order_Management.Models
{
    public class Token : EntityBase
    {
        public Token()
        {
            Status = Status.Processing;
        }

        public int OrderId { get; set; }
        public Status Status { get; set; }
        public bool Urgent { get; set; }
        
        [MaxLength(100)]
        public string Description { get; set; }
        public PayMethod PayMethod { get; set; }

        public virtual Order Order { get; set; }
    }
}
