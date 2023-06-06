using Microsoft.Extensions.DependencyInjection;
using SolarCoffe.Service.Products;
using SolarCoffe.Service.Orders;
using SolarCoffe.Service.Inventoies;
using SolarCoffe.Service.Customers;
using Microsoft.Extensions.Configuration;
using SolarCoffe.Service.Session;
using SolarCoffe.Service.Session.Auth;

namespace SolarCoffe.Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServiceLayer(this IServiceCollection services, IConfiguration configuration)
        {

            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IInventoryService, InventoryService>();

            services.AddSingleton<IJWT, JwtTokenGenerator>();
            services.AddSingleton<IAuthService, AuthenticationService>();

            
            return services;
        }
    }
}
