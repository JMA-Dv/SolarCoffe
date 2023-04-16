using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SolarCoffe.Api.Serialization;
using SolarCoffe.Api.ViewModels;
using SolarCoffe.Service.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarCoffe.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customer;

        public CustomerController(ILogger<CustomerController> logger, ICustomerService customer)
        {
            _logger = logger;
            _customer = customer;
        }

        [HttpPost]
        public ActionResult CreateCustomer(CustomerModel customerModel)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _logger.LogInformation("Creating customer");

            customerModel.DateCreated = DateTime.UtcNow;
            customerModel.DateUpdaetd = DateTime.UtcNow;
            var customerData = CustomerMapper.SerializeCustomer(customerModel);
            var newCustomer = _customer.CreateCustomer(customerData);
            return Ok(newCustomer);
        }

        [HttpGet]
        public ActionResult GetCustomers()
        {
            var customers = _customer.GetAllCustomers();
            var customerModels = customers.Data.Select(x => new CustomerModel
            {
                CustomerAddress = CustomerAddressMapper.MapCustomerAddress(x.CustomerAddress),
                DateCreated = x.DateCreated,
                DateUpdaetd = x.DateUpdaetd,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Id = x.Id
               
            }).OrderByDescending(X=> X.DateCreated).ToList();

            return Ok(customerModels);
        }
        
        [HttpDelete("{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            _logger.LogInformation("Deleteing customer");
            var response = _customer.DeleteCustomer(id);

            return Ok(response);
        }

          
    }
}
