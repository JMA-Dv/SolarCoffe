using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SolarCoffe.Data;
using SolarCoffe.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolarCoffe.Service.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly SolarCoffeDbContext _context;
        private readonly ILogger<CustomerService> _logger;

        public CustomerService(SolarCoffeDbContext context, ILogger<CustomerService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public ServiceResponse<Customer> CreateCustomer(Customer customer)
        {

            try
            {
                _logger.LogInformation("Creating customer ");
                var result = _context.Customers.Add(customer);
                _logger.LogInformation("Creating customer Address");
                _context.CustomerAddresses.Add(customer.CustomerAddress);

                _context.SaveChanges();
                return new ServiceResponse<Customer>
                {
                    Data = result.Entity,
                    IsSuccess = true,
                    Message = "Successfully created"
                };
            }
            catch (Exception e)
            {

                return new ServiceResponse<Customer>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = e.StackTrace
                };
            }
             
        }

        /// <summary>
        /// Delete Customer by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ServiceResponse<bool> DeleteCustomer(int id)
        {
            try
            {
                var customer = GetById(id);

                if (customer.Data == null)
                {
                    return new ServiceResponse<bool>
                    {
                        Data = false,
                        Message = "Could not find record",
                        IsSuccess = false
                    };
                }

                _context.Customers.Remove(customer.Data);
                _context.SaveChanges();

                return new ServiceResponse<bool>
                {
                    Data = true,
                    Message = "Deleted customer",
                    IsSuccess = true
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
        /// <summary>
        /// Returns a list of customers from db
        /// </summary>
        /// <returns></returns>
        public ServiceResponse<IReadOnlyList<Customer>> GetAllCustomers()
        { 
            try
            {
                var result = _context
                .Customers
                .Include(c => c.CustomerAddress)
                .OrderBy(c => c.LastName)
                .ToList().AsReadOnly();

                return new ServiceResponse<IReadOnlyList<Customer>>
                {
                    Data = result,
                    IsSuccess = true,
                    Message = "Successfully retrieved data",
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<IReadOnlyList<Customer>>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "Failed to retrieve data",
                };
            }
        }


        /// <summary>
        /// Get customer by Id
        /// </summary>
        /// <param name="id">Int customer primary key</param>
        /// <returns></returns>
        public ServiceResponse<Customer> GetById(int id)
        {
            try
            {
                var result = _context.Customers
                .Include(x => x.CustomerAddress)
                .Where(x => x.Id == id).FirstOrDefault();

                if (result == null)
                {
                    return new ServiceResponse<Customer>
                    {
                        Data = null,
                        IsSuccess = true,
                        Message = "Could not find provided customer",
                        Time = DateTime.UtcNow
                    };
                }

                return new ServiceResponse<Customer>
                {
                    Data = result,
                    IsSuccess = true,
                    Message = "Success",
                    Time = DateTime.UtcNow
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<Customer>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = e.StackTrace,
                    Time = DateTime.UtcNow
                };
            }
        }
    }
}
