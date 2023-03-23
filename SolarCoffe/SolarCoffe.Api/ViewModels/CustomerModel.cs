namespace SolarCoffe.Api.ViewModels
{
    public class CustomerModel:BaseClassModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public CustomerAddressModel CustomerAddress { get; set; }
    }
}