using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SolarCoffe.Api.Serialization;
using SolarCoffe.Service.Products;
using System.Linq;

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
            var response = _product.GetProducts();
            var products = response.Select(ProductMapper.SerializeProductModel);
            return Ok(products);
        }
    }
}
