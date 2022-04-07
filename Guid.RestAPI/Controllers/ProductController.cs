using Microsoft.AspNetCore.Mvc;
using Product.Domain.Models;


namespace Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductsService _productsService;

        public ProductController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        /// <summary>
        /// Endpoint to get all Products
        /// </summary>
        /// <returns> OK, NoContent</returns>
        /// <response code="200"> Products list </response>
        /// <response code="204"> No content </response>
        [HttpGet]
        [Route("GetAllProducts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<List<ProductsDto>>> GetAllProducts()
        {
            var result = await _productsService.GetAllProductsAsync();
            return !result.Any() ? NoContent() : Ok(result);
        }

        /// <summary>
        /// Endpoint to get Product by id
        /// </summary>
        /// <returns> OK, NoContent </returns>
        /// <response code="200"> Product  </response>
        /// <response code="400"> Bad Request </response>
        [HttpGet("GetAllProductsById/{id}")]
        public async Task<ActionResult<ProductsDto>> GetProductById(Guid id)
        {
            var result = await _productsService.GetProductByIdAsync(id);
            return Ok(result);
        }

        /// <summary>
        /// Endpoint to Create Product
        /// </summary>
        /// <returns> OK, NoContent</returns>
        /// <response code="200"> Create Product </response>
        /// <response code="400"> Bad Request </response>
        [HttpPost]
        [Route("CreateProducts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<System.Guid>> CreateProducts(ProductsDto productsDto)
        {
            await _productsService.CreateProductsAsync(productsDto);
            return Ok();
        }

        /// <summary>
        /// Endpoint to Update Product
        /// </summary>
        /// <returns> OK, NoContent</returns>
        /// <response code="200"> Create Product </response>
        /// <response code="400"> Bad Request </response>
        [HttpPut("UpdateProducts/{id}")]
        public async Task<ActionResult> UpdateProductsAsync(System.Guid id, string description, int quantity)
        {
            await _productsService.UpdateProductsAsync(id, description, quantity);
            return Ok();
        }

        /// <summary>
        /// Endpoint to Delete Product
        /// </summary>
        /// <returns> OK, NoContent</returns>
        /// <response code="200"> Create Product </response>
        /// <response code="400"> Bad Request </response>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProductsAsync(System.Guid id)
        {
            await _productsService.DeleteProductsAsync(id);
            return Ok();
        }
    }
}
