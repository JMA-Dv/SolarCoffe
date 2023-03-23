using SolarCoffe.Api.ViewModels;
using SolarCoffe.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarCoffe.Api.Serialization
{
    public static class OrderMapper
    {

        /// <summary>
        /// Maps an InvoiceModel view model to SalesOrder data model
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        public static SalesOrder SerializeInvoiceOrder(InvoiceModel invoice)
        {

            var salesOrderItems = invoice.LineItems
                .Select(item => new SalesOrderItem
                {
                    Id = item.Id,
                    Quantity = item.Quantity,
                    Product = ProductMapper.SerializeProductModel(item.Product)
                }).ToList();

            return new SalesOrder
            {
                CustomerId = invoice.CustomerId,
                DateCreated = DateTime.UtcNow,
                Id = invoice.Id,
                DateUpdaetd = invoice.DateUpdaetd,
                SalesOrderItems = salesOrderItems
            };
        }

        public static List<OrderModel> SerializeorderToViewModel(IEnumerable<SalesOrder> orders)
        {
            return orders.Select(order => new OrderModel
            {
                Id = order.Id,
                DateCreated = order.DateCreated,
                DateUpdaetd = order.DateUpdaetd,
                Customer = CustomerMapper.SerializeCustomer(order.Customer),
                IsPaid = order.IsPaid,

                SalesOrderItems = SerializeSalesOrderItems(order.SalesOrderItems)
                
            }).ToList();
        }

        /// <summary>
        /// Maps a collection of SalesOrderItems to SalesOrderItemModels
        /// </summary>
        /// <param name="orderItems"></param>
        /// <returns></returns>
        private static List<SalesOrderItemModel> SerializeSalesOrderItems(IEnumerable<SalesOrderItem> orderItems)
        {
            
            return orderItems.Select(item => new SalesOrderItemModel
            {
                Id = item.Id,
                Product = ProductMapper.SerializeProductModel(item.Product),
                Quantity = item.Quantity
            }).ToList();
        }
    }
}
