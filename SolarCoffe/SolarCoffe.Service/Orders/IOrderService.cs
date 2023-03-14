using SolarCoffe.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolarCoffe.Service.Orders
{
    public interface IOrderService
    {
        List<SalesOrder> GetOrders();
        ServiceResponse<bool> GenerateOrderInvoice(SalesOrder order);
        ServiceResponse<bool> MarkFulfolled(int id);

    }
}
