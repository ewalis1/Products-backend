using FluentValidation;
using Product.Domain.Models;

namespace Product
{
    public static class IocExtension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<ProductsService, ProductsService>();
        }

        public static void RegisterRepository(this IServiceCollection services)
        {
            services.AddTransient<IProductsRepository, ProductsRepository>();
        }
    }
}
