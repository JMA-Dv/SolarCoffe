using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SolarCoffe.Data;
using SolarCoffe.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolarCoffe.Service.Inventoies
{
    public class InventoryService : IInventoryService
    {
        private readonly SolarCoffeDbContext _context;
        private readonly ILogger<IInventoryService> _logger;

        public InventoryService(SolarCoffeDbContext context, ILogger<IInventoryService> logger)
        {
            _context = context;
            _logger = logger;
        }

        private void CreateSnapshot(ProductInventory inventory)
        {
            var snapshot = new ProductInventorySnapshot
            {
                SnapshotTime = DateTime.UtcNow,
                Product = inventory.Product,
                QuantityOnHand = inventory.QuantityOnHand

            };

            _context.ProductInventorySnapshots.Add(snapshot);
        }

        public ProductInventory GetByProductId(int productId)
        {
                return _context.ProductInventories.Include(p => p.Product)
                    .FirstOrDefault(x=> x.Product.Id == productId);
                 
        }

        public IReadOnlyCollection<ProductInventory> GetCurrentInventory()
        {
                var result = _context.ProductInventories.Include(x => x.Product)
                    .Where(x => x.Product.IsArchived
                    ).ToList().AsReadOnly();

                return result;
        }

        /// <summary>
        /// Returns Snapshot history for previoues 6 hours
        /// </summary>
        /// <returns></returns>
        public List<ProductInventorySnapshot> GetSnapshotHistory()
        {
            var earliest = DateTime.UtcNow - TimeSpan.FromHours(6);
            return _context.ProductInventorySnapshots
                .Include(x => x.Product)
                .Where(x => x.SnapshotTime > earliest 
                && !x.Product.IsArchived).ToList();
        }

        /// <summary>
        /// Updates number of units available of the provided product id    
        /// Adjust QuantityOnHand by adjustment value
        /// Snapshot is to keep track of ever
        /// </summary>
        /// <param name="id">productId</param>
        /// <param name="adjustment">Number of units added/ removed from invengtory</param>
        /// <returns></returns>
        public ServiceResponse<ProductInventory> UpdateUnitsAvailable(int id, int adjustment)
        {
            try
            {
                var inventory = _context.ProductInventories
                    .Include(x => x.Product)
                    .First(x => x.Product.Id == id);

                inventory.QuantityOnHand += adjustment;


                try
                {
                    CreateSnapshot(inventory);
                }
                catch (Exception e)
                {

                    _logger.LogError("Errror createing inventory snapshot");
                    _logger.LogError(e.StackTrace);

                }

                _context.SaveChanges();

                return new ServiceResponse<ProductInventory>
                {
                    Data = inventory,
                    IsSuccess = true,
                    Message = "Inventory Adjusted",

                };
            }
            catch (Exception e)
            {

                return new ServiceResponse<ProductInventory>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "Error updating Product Quantity On hand " + e.StackTrace,

                };
            }
        }
    }
}
