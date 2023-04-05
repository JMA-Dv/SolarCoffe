using System.ComponentModel.DataAnnotations;

namespace SolarCoffe.Api.ViewModels
{
    public class CustomerAddressModel:BaseClassModel
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string AddressLine { get; set; }
        [MaxLength(50)]
        public string City { get; set; }
        [MaxLength(50)]
        public string State { get; set; }
        [MaxLength(50)]
        public string PostalCode { get; set; }
        [MaxLength(50)]
        public string Country { get; set; }
    }
}