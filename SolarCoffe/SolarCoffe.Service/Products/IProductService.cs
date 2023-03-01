using SolarCoffe.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolarCoffe.Service.Products
{
    public interface IProductService
    {
        IReadOnlyList<Product> GetProducts();
        Product GetProductById(int id);
        ServiceResponse<Product> CreateProduct(Product product);
        ServiceResponse<Product> ArchiveProduct(int id);


         
    }
}
