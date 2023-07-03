using SolarCoffe.Data.Models;
using SolarCoffe.Data.Repositories.Common;
using SolarCoffe.Data.Requests.Customers;
using SolarCoffe.Data.Responses;

namespace SolarCoffe.Data.Repositories.Customers
{
    public interface ICustomerRepository : IRepository<Response<CustomerResponse>, CustomerRequest>
    {

    }
}
