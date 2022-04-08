using Product.Domain.Models;

namespace Product
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<IList<ProductsDto>> GetAllProductsAsync()
        {
            var numberOfProducts = await _productsRepository.CountProducts();
            if (numberOfProducts > 0) return await _productsRepository.GetAllProductsAsync();
            else return null;
        }

        public async Task<ProductsDto> GetProductByIdAsync(System.Guid id)
        {
            var productExists = await _productsRepository.CheckIfProductExistsAsync(id);
            if (!productExists) throw new ArgumentNullException("Product with this id doesn't exist");
            return await _productsRepository.GetProductByIdAsync(id);
        }

        public async Task<System.Guid> CreateProductsAsync(ProductsDto productsDto)
        {
            var productExists = await _productsRepository.CheckIfProductExistsAsync(productsDto.Id);
            if (productExists) throw new ArgumentException("Product with this Id already exists");
            return await _productsRepository.CreateProductsAsync(productsDto);
        }

        public async Task UpdateProductsAsync(System.Guid id, string description, int quantity)
        {
            var productExists = await _productsRepository.CheckIfProductExistsAsync(id);
            if (!productExists) throw new ArgumentNullException("Product with this id doesn't exist");
            await _productsRepository.UpdateProductsAsync(id, description, quantity);
        }

        public async Task DeleteProductsAsync(System.Guid id)
        {
            var productExists = await _productsRepository.CheckIfProductExistsAsync(id);
            if (!productExists) throw new ArgumentNullException("Product with this id doesn't exist");
            await _productsRepository.DeleteProductsAsync(id);
        }
    }
}
