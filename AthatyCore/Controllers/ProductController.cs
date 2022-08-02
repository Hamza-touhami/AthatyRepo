using AthatyCore.DTOs;
using AthatyCore.Entities;
using AthatyCore.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AthatyCore.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        //GET /items
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductsAsync(Guid productId)
        {
            var products = (await productRepository.GetProductsAsync());
            if(products is null)
                return NotFound();
            return AcceptedAtAction(nameof(GetProductsAsync), products.Select(product => product.AsDTO()));  
        }

        //GET /items/id=*******
        [HttpGet("{productId}")]
        public async Task<ActionResult<ProductDto>> GetProductAsync(Guid productId)
        {
            var product = (await productRepository.GetProductAsync(productId));
            if(product is null)
                return NotFound();
            return product.AsDTO();
        }

        //POST /items
        //Here we return ItemDto although it's a post request, because it's a convention we send back the item that was created
       
        [HttpPost]
        public async Task<ActionResult<ProductDto>> CreateProductAsync(CreatedProductDto productDto)
        {
            Product product = new()
            {
                Name = productDto.Name,
                Id = Guid.NewGuid(),
                CategoryId = productDto.CategoryId
            };

            await productRepository.AddProductAsync(product);

            return CreatedAtAction(nameof(CreateProductAsync), new {id = product.Id}, product.AsDTO());
        }

        [HttpPut("{productId}")]
        public async Task<ActionResult> UpdateProductAsync(Guid productId, UpdatedProductDto productDto)
        {
            var existingProduct = await productRepository.GetProductAsync(productId);

            if(existingProduct is null)
            {
                return NotFound();
            }
            
            Product updateProduct = existingProduct with
            {
                Name = productDto.Name,
            };

            await productRepository.UpdateProductAsync(updateProduct);
            
            return NoContent();
        }

        [HttpDelete("{productId}")]
        public async Task<ActionResult> DeleteProductAsync(Guid productId)
        {
            var existingProduct = await productRepository.GetProductAsync(productId);
            if(existingProduct is null)
            {
                return NotFound();
            }

            await productRepository.DeleteProductAsync(existingProduct);

            return NoContent();
        }
        
    }
}