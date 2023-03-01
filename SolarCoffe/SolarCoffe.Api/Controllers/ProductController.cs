using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SolarCoffe.Service.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarCoffe.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _Logger;
        private readonly IProductService _product;

        public ProductController(ILogger<ProductController> logger, IProductService product)
        {
            _Logger = logger;
            _product = product;
        }

        [HttpGet]
        public ActionResult GetProduct()
        {
            _Logger.LogInformation("Getting all info");
            var response = 
            return Ok();
        }
    }
}
