using SolarCoffe.Api.ViewModels;
using SolarCoffe.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarCoffe.Api.Serialization
{
    public static class CustomerMapper
    {
        /// <summary>
        /// Maps a customer entity to a Customer Model
        /// </summary>
        /// <param name="customer">CustomerEntity</param>
        /// <returns></returns>
        public static CustomerModel SerializeCustomer(Customer customer)
        {
            


            return new CustomerModel
            {
                CustomerAddress = CustomerAddressMapper.MapCustomerAddress(customer.CustomerAddress),
                Id = customer.Id,
                DateUpdaetd = customer.DateUpdaetd,
                DateCreated = customer.DateCreated,
                FirstName = customer.FirstName,
                LastName = customer.LastName
            };
        }
        
        /// <summary>
        /// Maps a customer model to a customer entity
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static Customer SerializeCustomer(CustomerModel customer)
        {
            return new Customer
            {
                CustomerAddress = CustomerAddressMapper.MapCustomerAddress(customer.CustomerAddress),
                
                DateUpdaetd = customer.DateUpdaetd,
                DateCreated = customer.DateCreated,
                 FirstName = customer.FirstName,
                LastName = customer.LastName 
            };
        }
    }
}
