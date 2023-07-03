using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SolarCoffe.Data.Models;
using SolarCoffe.Data.Models.Auth;
using SolarCoffe.Data.Models.Config;

namespace SolarCoffe.Data
{
    public class SolarCoffeDbContext : IdentityDbContext
    {
        public SolarCoffeDbContext(DbContextOptions<SolarCoffeDbContext> options) : base(options)
        {
        }

        protected SolarCoffeDbContext()
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductInventory> ProductInventories { get; set; }
        public DbSet<ProductInventorySnapshot> ProductInventorySnapshots { get; set; }
        public DbSet<SalesOrder> SalesOrders { get; set; }
        public DbSet<SalesOrderItem> SalesOrderItems { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            new ApplicationUserConfig(builder.Entity<ApplicationUser>());
            new ApplicationRoleConfig(builder.Entity<ApplicationRole>());
        }
    }
}
