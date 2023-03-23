using System.ComponentModel.DataAnnotations;

namespace SolarCoffe.Data.Models
{
    public class Customer:BaseClass
    {
        public int Id { get; set; }
        [MaxLength(32)]
        public string FirstName { get; set; }
        [MaxLength(32)]
        public string LastName { get; set; }
        public CustomerAddress CustomerAddress { get; set; }
    }
}
