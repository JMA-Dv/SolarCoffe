using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SolarCoffe.Api.Serialization;
using SolarCoffe.Api.ViewModels;
using SolarCoffe.Service.Customers;
using SolarCoffe.Service.Orders;
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
        private readonly IOrderService _orderService;

        public OrderController(ILogger<OrderController> logger, IProductService productService, ICustomerService customerService, IOrderService orderService)
        {
            _logger = logger;
            _productService = productService;
            _customerService = customerService;
            _orderService = orderService;
        }

        [HttpPost("invoice")]
        public ActionResult GenerateNewOrder(InvoiceModel invoice)
        {
            _logger.LogInformation("Generating invoice");
            var order = OrderMapper.SerializeInvoiceOrder(invoice);


            order.Customer = _customerService.GetById(invoice.CustomerId).Data;
            _orderService.GenerateOrderInvoice(order);
            return Ok();
        }
    }
}
