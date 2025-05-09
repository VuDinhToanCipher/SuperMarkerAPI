using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SuperMarkerAPI.Data;
using SuperMarket.Application.Interfaces;
using SuperMarket.Application.Services;
using SuperMarket.Core.Interfaces;
using SuperMarket.Infrastructure.Repositories;

namespace SuperMarket.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductTypeRepository, ProductTypeRepository>();
            services.AddScoped<ISupplierRespository, SupplierRespository>();
            services.AddScoped<IProductServices, ProductService>();
            services.AddScoped<IproductTypeService, ProductTypeService>();
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<IProduct_Supplier_Service, Product_Supplier_Service>();
            services.AddScoped<IProduct_Supplier_Respository,Product_Supplier_Repository>();

            // Sign in validation
            
          
            return services;
        }

    }
}
