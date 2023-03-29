using SolarCoffe.Api.ViewModels;
using SolarCoffe.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarCoffe.Api.Serialization
{
    public static class CustomerAddressMapper
    {
        public static CustomerAddressModel? MapCustomerAddress(CustomerAddress customerAddress)
        {

            return (customerAddress != null) ?  new CustomerAddressModel
            {
                Id = customerAddress.Id,
                AddressLine = customerAddress.AddressLine,
                City = customerAddress.City,
                Country = customerAddress.Country,
                DateCreated = customerAddress.DateCreated,
                DateUpdaetd = customerAddress.DateUpdaetd,
                PostalCode = customerAddress.PostalCode,
                State = customerAddress.State
            }: null;
            
        }
        
        public static CustomerAddress MapCustomerAddress(CustomerAddressModel customerAddress)
        {

            return new CustomerAddress
            {
                Id = customerAddress.Id,
                AddressLine = customerAddress.AddressLine,
                City = customerAddress.City,
                Country = customerAddress.Country,
                DateCreated = customerAddress.DateCreated,
                DateUpdaetd = customerAddress.DateUpdaetd,
                PostalCode = customerAddress.PostalCode,
                State = customerAddress.State
            };
            
        }
    }
}
