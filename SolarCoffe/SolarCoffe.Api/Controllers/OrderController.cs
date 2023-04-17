using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SolarCoffe.Api.Serialization;
using SolarCoffe.Api.ViewModels;
using SolarCoffe.Service.Customers;
using SolarCoffe.Service.Orders;
using SolarCoffe.Service.Products;

namespace SolarCoffe.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;

        private readonly ICustomerService _customerService;
        private readonly IOrderService _orderService;

        public OrderController(ILogger<OrderController> logger, ICustomerService customerService, IOrderService orderService)
        {
            _logger = logger;
            _customerService = customerService;
            _orderService = orderService;
        }

        [HttpPost("invoice")]
        public IActionResult GenerateNewOrder(InvoiceModel invoice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _logger.LogInformation("Generating invoice");
            var order = OrderMapper.SerializeInvoiceOrder(invoice);


            order.Customer = _customerService.GetById(invoice.CustomerId).Data;
             
            _orderService.GenerateOrderInvoice(order);
            return Ok();
        }


        [HttpGet]
        public IActionResult GetOrders()
        {
            var orders = _orderService.GetOrders();

            var orderModels = OrderMapper.SerializeorderToViewModel(orders);
            return Ok(orderModels);

        }            
         
        [HttpPatch("{id}")]
        public IActionResult MarkAsComplete(int id)
        {
            _logger.LogInformation("Maring order as complete");
            var response = _orderService.MarkFulfolled(id);

            return Ok(response);
        }
    }
}
