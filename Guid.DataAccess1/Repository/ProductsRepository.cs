using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Product.DataAccess;
using Product.DataAccess.Models;
using Product.Domain.Models;

namespace Product
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly IMapper _mapper;
        private readonly ProductContext _context;

        public DbContextOptions<ProductContext> ConnectionString { get; private set; }

        public ProductsRepository(IMapper mapper, ProductContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IList<ProductsDto>> GetAllProductsAsync()
        {
            return _mapper.Map<List<ProductsDto>>(await _context.Products.ToListAsync());
        }

        public async Task<ProductsDto> GetProductByIdAsync(Guid id)
        {
            return _mapper.Map<ProductsDto>(_context.Products.FirstOrDefault(p => p.Id == id));
        }

        public async Task<Guid> CreateProductsAsync(ProductsDto productsDto)
        {
            var product = (_mapper.Map<Products>(productsDto));
            _context.Products.Add(product);
            try
            {
                _context.SaveChanges();
                await Task.CompletedTask;
                return product.Id;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception();
            }
            
        }

        public async Task UpdateProductsAsync(Guid id, string description, int quantity)
        {
            var products = new Products() {Id = id, Description = description, Quantity = quantity};
            await using (var db = new ProductContext(ConnectionString))
            {
                db.Products.Attach(products);
                db.Entry(products).Property(x => x.Description).IsModified = true;
                db.Entry(products).Property(x => x.Quantity).IsModified = true;
                db.SaveChanges();
            }
        }

        public async Task DeleteProductsAsync(Guid id)
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == id);
            try
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public async Task<int> CountProducts()
        {
            await Task.CompletedTask;
            return _context.Products.Count();
        }

        public async Task<bool> CheckIfProductExistsAsync(Guid id)
        {
            await Task.CompletedTask;
            return (_context.Products).Any(p => p.Id == id);
        }

    }
}
