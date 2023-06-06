using SolarCoffe.Data;
using SolarCoffe.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolarCoffe.Service.Products
{
    public class ProductService : IProductService
    {
        private readonly SolarCoffeDbContext _context;

        public ProductService(SolarCoffeDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Simulates a delete by archive the record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ServiceResponse<Product> ArchiveProduct(int id)
        {
            try
            {
                var product = _context.Products.Find(id);
                

                product.IsArchived = true;
                product.DateUpdaetd = DateTime.UtcNow;

                _context.SaveChanges();
                return new ServiceResponse<Product>
                {
                    Data = product,
                    IsSuccess = true,
                    Message = "Entity updated successfully",
                    Time = DateTime.UtcNow
                };
            }
            catch (Exception e)
            {

                return new ServiceResponse<Product>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = e.StackTrace,
                    Time = DateTime.UtcNow
                };
            }
            
        }

        /// <summary>
        /// Adds a new product to the database
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public ServiceResponse<Product> CreateProduct(Product product)
        {
            try
            {
                _context.Products.Add(product);
                var newInventory = new ProductInventory
                {
                    Product = product,
                    QuantityOnHand = 0,
                    IdealQuantity = 10

                };
                _context.ProductInventories.Add(newInventory);

                _context.SaveChanges();

                return new ServiceResponse<Product>
                {

                    Data = product,
                    Time = DateTime.UtcNow,
                    Message = "Saved new product",
                    IsSuccess = true

                };
            }
            catch (Exception e)
            {

                return new ServiceResponse<Product>
                {
                    Data = product,
                    Time = DateTime.UtcNow,
                    Message = "Error saving new product",
                    IsSuccess = false
                };
            }
            
        }
        /// <summary>
        /// Retrieves a product by product id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ServiceResponse<Product> GetProductById(int id)
        {
            try
            {
                var result = _context.Products.Find(id);
                return new ServiceResponse<Product>
                {
                    Data = result,
                    Time = DateTime.UtcNow,
                    IsSuccess = true,
                    Message = "Successfully retrieved data"
                };
            }
            catch (Exception e)
            {

                return new ServiceResponse<Product>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = e.StackTrace,
                    Time = DateTime.UtcNow
                };
            }
        }
        /// <summary>
        /// Retrieves all products
        /// </summary>
        /// <returns></returns>
        public ServiceResponse<IReadOnlyList<Product>> GetProducts()
        {

            try
            {
                var result = _context.Products.ToList().AsReadOnly();
                return new ServiceResponse<IReadOnlyList<Product>>
                {
                    Data = result,
                    IsSuccess = true,
                    Message = "Successfully retrieved data"
                };

            }
            catch (Exception e)
            {
                return new ServiceResponse<IReadOnlyList<Product>>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = e.StackTrace
                };


            }
        }
    }
}
