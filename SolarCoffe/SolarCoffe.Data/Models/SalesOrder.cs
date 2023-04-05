using System;
using System.Collections.Generic;
using System.Text;

namespace SolarCoffe.Data.Models
{
    public class SalesOrder:BaseClass
    {
        public int Id { get; set; }
        public ICollection<SalesOrderItem> SalesOrderItems { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public bool IsPaid { get; set; }
    }
}

