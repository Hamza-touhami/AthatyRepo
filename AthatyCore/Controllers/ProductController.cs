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
        private readonly ICategoryRepository categoryRepository;

        public ProductController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        //GET /items
        [HttpGet("{categoryId}")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductsAsync(Guid categoryId)
        {
            var products = (await categoryRepository.GetProductsAsync(categoryId));
            if(products is null)
                return NotFound();
            return AcceptedAtAction(nameof(GetProductsAsync), products.Select(product => product.AsDTO()));  
        }

        //GET /items/id=*******
        [HttpGet("{categoryId}/{productId}")]
        public async Task<ActionResult<ProductDto>> GetProductAsync(Guid categoryId, Guid productId)
        {
            var product = (await categoryRepository.GetProductAsync(categoryId, productId));
            if(product is null)
                return NotFound();
            return product.AsDTO();
        }

        //POST /items
        //Here we return ItemDto although it's a post request, because it's a convention we send back the item that was created
       
        [HttpPost]
        public async Task<ActionResult<CategoryDto>> CreateProductAsync(CreatedProductDto productDto)
        {
            Product product = new()
            {
                Name = productDto.Name,
                Id = Guid.NewGuid(),
                CategoryId = productDto.CategoryId
            };

            await categoryRepository.AddProductAsync(productDto.CategoryId, product);

            return CreatedAtAction(nameof(CreateProductAsync), new {id = product.Id}, product.AsDTO());
        }

        [HttpPut("{categoryId}/{productId}")]
        public async Task<ActionResult> UpdateProductAsync(Guid categoryId, Guid productId, UpdatedProductDto productDto)
        {
            var existingProduct = await categoryRepository.GetProductAsync(categoryId, productId);

            if(existingProduct is null)
            {
                return NotFound();
            }
            
            Product updateProduct = existingProduct with
            {
                Name = productDto.Name,
            };

            await categoryRepository.UpdateProductAsync(categoryId, updateProduct);
            
            return NoContent();
        }

        [HttpDelete("{categoryId}/{productId}")]
        public async Task<ActionResult> DeleteProductAsync(Guid categoryId, Guid productId)
        {
            var existingProduct = await categoryRepository.GetProductAsync(categoryId, productId);
            if(existingProduct is null)
            {
                return NotFound();
            }

            await categoryRepository.DeleteProductAsync(categoryId, existingProduct);

            return NoContent();
        }
        
    }
}