
using System;

namespace SolarCoffe.Data.Models
{
    public class ProductInventorySnapshot:BaseClass
    {
        public int Id { get; set; }
        public DateTime  SnapshotTime { get; set; }
        public int QuantityOnHand { get; set; }
        public Product Product { get; set; }

    }
}
