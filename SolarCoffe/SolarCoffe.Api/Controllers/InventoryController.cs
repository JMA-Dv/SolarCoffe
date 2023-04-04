using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SolarCoffe.Api.Serialization;
using SolarCoffe.Api.ViewModels;
using SolarCoffe.Service.Inventoies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarCoffe.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventory;
        private readonly ILogger<InventoryController> _logger;

        public InventoryController(IInventoryService inventory, ILogger<InventoryController> logger)
        {
            _inventory = inventory;
            _logger = logger;
        }


        [HttpGet]
        public IActionResult GetCurrentInventory()
        {
            _logger.LogInformation("Gerring all inventory");
            var inventory = _inventory.GetCurrentInventory().Select(x => new ProductInventoryModel
            {
                DateCreated = x.DateCreated,
                DateUpdaetd = x.DateUpdaetd,
                Product = ProductMapper.SerializeProductModel(x.Product),
                Id = x.Id,
                IdealQuantity = x.IdealQuantity,
                QuantityOnHand = x.QuantityOnHand
                }).OrderBy(x=> x.Product.Name)
            .ToList();

            return Ok(inventory);
        }

        [HttpPatch]
        public IActionResult UpdateInventory(ShipmentModel shipment)
        {
            _logger.LogInformation("Updating inventory" + $"for {shipment.ProductId}" + $" Adjustment: {shipment.Adjustment}");

            var inventory = _inventory.UpdateUnitsAvailable(shipment.ProductId, shipment.Adjustment);

            return Ok(inventory);
        }



    }
}
