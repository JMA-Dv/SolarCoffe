using SolarCoffe.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolarCoffe.Service.Inventoies
{
    public interface IInventoryService
    {
        IReadOnlyCollection<ProductInventory> GetCurrentInventory();
        ServiceResponse<ProductInventory> UpdateUnitsAvailable(int id, int adjustment);
        ProductInventory GetByProductId(int productId);
        
        List<ProductInventorySnapshot> GetSnapshotHistory();

    }
}
