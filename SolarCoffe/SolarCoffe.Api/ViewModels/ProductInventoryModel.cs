namespace SolarCoffe.Api.ViewModels
{
    public class ProductInventoryModel:BaseClassModel
    {
        public int Id { get; set; }
        public int QuantityOnHand { get; set; }
        public int IdealQuantity { get; set; }
        public ProductModel Product { get; set; }
    }
}
