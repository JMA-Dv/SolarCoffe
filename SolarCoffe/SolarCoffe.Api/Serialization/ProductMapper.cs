using SolarCoffe.Api.ViewModels;
using SolarCoffe.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarCoffe.Api.Serialization
{
    public class ProductMapper
    {
        /// <summary>
        /// Maps a product to a view model
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public static ProductModel SerializeProductModel(Product product)
        {
            return new ProductModel
            {
                Id = product.Id,
                DateCreated = product.DateCreated,
                DateUpdaetd = product.DateUpdaetd,
                Description = product.Description,
                IsArchived = product.IsArchived,
                Name = product.Name,
                Price = product.Price,
                Taxeable = product.Taxeable
            };
        }

        /// <summary>
        /// Maps a view model to a product 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public static Product SerializeProductModel(ProductModel product)
        {
            return new Product
            {
                Id = product.Id,
                DateCreated = product.DateCreated,
                DateUpdaetd = product.DateUpdaetd,
                Description = product.Description,
                IsArchived = product.IsArchived,
                Name = product.Name,
                Price = product.Price,
                Taxeable = product.Taxeable
            };
        }
    }
}
