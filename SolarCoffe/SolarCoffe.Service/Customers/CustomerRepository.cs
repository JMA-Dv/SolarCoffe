using SolarCoffe.Data;
using SolarCoffe.Data.Models;
using SolarCoffe.Data.Repositories.Customers;
using SolarCoffe.Data.Requests.Customers;
using SolarCoffe.Data.Responses;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SolarCoffe.Service.Customers
{
    internal class CustomerRepository : ICustomerRepository
    {
        private readonly SolarCoffeDbContext _context;

        public CustomerRepository(SolarCoffeDbContext context)
        {
            _context = context;
        }

        public async Task<Response<CustomerResponse>> AddAsync(CustomerRequest entity)
        {
            await _context.SaveChangesAsync();
        }

        public Task<Response<CustomerResponse>> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Response<CustomerResponse>> FindAsync(Expression<Func<CustomerRequest, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Response<CustomerResponse>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Response<CustomerResponse>> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<CustomerResponse>> UpdateAsync(CustomerRequest entity)
        {
            throw new NotImplementedException();
        }
    }
}
