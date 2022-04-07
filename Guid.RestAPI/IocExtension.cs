using FluentValidation;
using Product.Domain.Models;
using Product.Services;

namespace Product
{
    public static class IocExtension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ProductsService, Services.ProductsService>();
        }

        public static void RegisterRepository(this IServiceCollection services)
        {
            services.AddScoped<IProductsRepository, ProductsRepository>();
        }
    }
}
