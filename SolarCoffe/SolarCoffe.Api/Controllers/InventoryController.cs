using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
            return Ok();
        }

    }
}
