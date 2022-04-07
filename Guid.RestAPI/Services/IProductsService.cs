using Product.Domain.Models;

namespace Product
{
    public interface IProductsService
    {
        Task<IList<ProductsDto>> GetAllProductsAsync();

        Task<ProductsDto> GetProductByIdAsync(System.Guid id);

        Task<System.Guid> CreateProductsAsync(ProductsDto productsDto);

        Task UpdateProductsAsync(System.Guid id, string description, int quantity);

        Task DeleteProductsAsync(System.Guid id);
    }
}
