using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SolarCoffe.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolarCoffe.Data
{
    public class SolarDbContext: IdentityDbContext
    {
        public SolarDbContext()
        {

        }

        public SolarDbContext(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; }
    }
}
