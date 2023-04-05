using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SolarCoffe.Data;
using SolarCoffe.Data.Models;
using SolarCoffe.Service.Inventoies;
using SolarCoffe.Service.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolarCoffe.Service.Orders
{
    public class OrderService : IOrderService
    {

        private readonly SolarCoffeDbContext _context;
        private readonly ILogger<OrderService> _logger;
        private readonly IProductService _productService;
        private readonly IInventoryService _inventoryService;

        public OrderService(SolarCoffeDbContext context, ILogger<OrderService> logger, IProductService productService, IInventoryService inventoryService)
        {
            _context = context;
            _logger = logger;
            _productService = productService;
            _inventoryService = inventoryService;
        }

        public ServiceResponse<bool> GenerateOrderInvoice(SalesOrder order)
        {
            _logger.LogInformation("Creating invoice");
            foreach (var item in order.SalesOrderItems)
            {
                item.Product = _productService.GetProductById(item.Product.Id).Data;


                var inventoryId = _inventoryService.GetByProductId(item.Product.Id).Id;

                _inventoryService.UpdateUnitsAvailable(inventoryId, -item.Quantity);

            }

            try
            {
                _context.SalesOrders.Add(order);
                _context.SaveChanges();

                return new ServiceResponse<bool>
                {
                    Data = true,
                    IsSuccess = true,
                    Message = "Order created"
                };
            }
            catch (Exception e)
            {

                return new ServiceResponse<bool>
                {
                    Data = false,
                    IsSuccess = false,
                    Message = e.StackTrace
                };
            }
        }

        public List<SalesOrder> GetOrders()
        {

            _logger.LogInformation("Getting orders data");
            return _context.SalesOrders
                .Include(x => x.Customer)
                    .ThenInclude(c => c.CustomerAddress)
                .Include(x => x.SalesOrderItems)
                    .ThenInclude(x => x.Product)
                .ToList();
        }
        /// <summary>
        /// Marks an order SalesOrder as paid
        /// </summary>
        /// <param name="id">Order's Id</param>
        /// <returns>True/False</returns>
        public ServiceResponse<bool> MarkFulfolled(int id)
        {


            try
            {
                var order = _context.SalesOrders.Find(id);
                order.DateUpdaetd = DateTime.UtcNow;
                order.IsPaid = true;
                _context.SalesOrders.Update(order);
                _context.SaveChanges();
                return new ServiceResponse<bool>
                {
                    IsSuccess = true,
                    Data = true,
                    Message = $"ORder{ order.Id} Closed: invoice paid"
                };
            }
            catch (Exception e)
            {

                return new ServiceResponse<bool>
                {
                    IsSuccess = false,
                    Data = false,
                    Message = e.StackTrace
                };
            }
        }
    }
}
