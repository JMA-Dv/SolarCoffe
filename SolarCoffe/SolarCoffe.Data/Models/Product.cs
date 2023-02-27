using System.ComponentModel.DataAnnotations;

namespace SolarCoffe.Data.Models
{
    public    class Product:BaseClass
    {
        public int Id { get; set; }
        [MaxLength(64)]
        public string Name { get; set; }
        [MaxLength(120)]
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool Taxeable { get; set; }
        public bool IsArchived { get; set; }
    }
}
