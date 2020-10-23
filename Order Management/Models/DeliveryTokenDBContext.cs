using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Order_Management.Models
{
    public class DeliveryTokenDB: DbContext
    {
        public DeliveryTokenDB(DbContextOptions<DeliveryTokenDB> options) : base(options)
        {

        }

        public DbSet<Token> Tokens { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Prescription> Prescription { get; set; }

        public override int SaveChanges()
        {
            ValidateEntities();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            ValidateEntities();
            return base.SaveChangesAsync(cancellationToken);
        }

        public Task<int> SaveChangesAsync()
        {
            ValidateEntities();
            return base.SaveChangesAsync();
        }

        protected virtual void ValidateEntities()
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>().Where(e => e.State == EntityState.Added))
            {
                entry.Entity.CreatedTime = entry.Entity.LastUpdatedTime = DateTime.Now;
            }

            foreach (var entry in ChangeTracker.Entries<EntityBase>().Where(e => e.State == EntityState.Modified))
            {
                entry.Entity.LastUpdatedTime = DateTime.Now;
            }
        }
    }
}
