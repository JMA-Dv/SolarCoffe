
using SolarCoffe.Data.Models;

namespace SolarCoffe.Data.Responses
{
    public class CustomerResponse:BaseClass
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
