using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SolarCoffe.Api.Serialization;
using SolarCoffe.Api.ViewModels;
using SolarCoffe.Service.Customers;
using SolarCoffe.Service.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarCoffe.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;

        private readonly IProductService _productService;
        private readonly ICustomerService _customerService;

        public OrderController(ILogger<OrderController> logger, IProductService productService, ICustomerService customerService)
        {
            _logger = logger;
            _productService = productService;
            _customerService = customerService;
        }

        [HttpPost("invoice")]
        public ActionResult GenerateNewOrder(InvoiceModel invoice)
        {
            _logger.LogInformation("Generating invoice");
            var order = OrderMapper.SerializeInvoiceOrder(invoice);

            order.Customer = _customerService.GetById(invoice.CustomerId);
            return Ok();
        }
    }
}
