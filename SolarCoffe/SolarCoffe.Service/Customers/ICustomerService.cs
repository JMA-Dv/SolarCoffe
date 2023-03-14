using SolarCoffe.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolarCoffe.Service.Customers
{
    public interface ICustomerService
    {
        ServiceResponse<IReadOnlyList<Customer>> GetAllCustomers();
        ServiceResponse<Customer> CreateCustomer(Customer customer);
        ServiceResponse<bool> DeleteCustomer(int id);
        ServiceResponse<Customer>GetById(int id);
    }
}
