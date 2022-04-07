using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Product.Domain.Models;

namespace Product;

public interface IProductsRepository
{
    Task<IList<ProductsDto>> GetAllProductsAsync();

    Task<ProductsDto> GetProductByIdAsync(Guid id);

    Task<Guid> CreateProductsAsync(ProductsDto productsDto);

    Task UpdateProductsAsync(Guid id, string description, int quantity);

    Task DeleteProductsAsync(Guid id);

    Task<int> CountProducts();

    Task<bool> CheckIfProductExistsAsync(Guid id);
}