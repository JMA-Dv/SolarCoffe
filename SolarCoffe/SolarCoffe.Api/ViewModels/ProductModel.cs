namespace SolarCoffe.Api.ViewModels
{
    /// <summary>
    /// Product entity DTO
    /// </summary>
    public class ProductModel:BaseClassModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool Taxeable { get; set; }
        public bool IsArchived { get; set; }
    }
}
