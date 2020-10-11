using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_Management.Models
{
    public class DeliveryTokenDB: DbContext
    {
        public DeliveryTokenDB(DbContextOptions<DeliveryTokenDB> options) : base(options)
        {

        }

        public DbSet<TokenDetail> TokenDetails { get; set; }
    }
}
