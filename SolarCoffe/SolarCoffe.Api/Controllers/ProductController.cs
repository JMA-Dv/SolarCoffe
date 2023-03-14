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
            var products = response.Data.Select(ProductMapper.SerializeProductModel);
            return Ok(products);
        }


        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            _Logger.LogInformation($"Getting product with id {id} ");

            var respose = _product.GetProductById(id);
            var product = ProductMapper.SerializeProductModel(respose.Data);

            return Ok(product);
        }


        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            _Logger.LogInformation($"Getting product with id {id} ");

            var response = _product.ArchiveProduct(id);
             ProductMapper.SerializeProductModel(response.Data);

            return Ok(response);
        }

        
    }
}
