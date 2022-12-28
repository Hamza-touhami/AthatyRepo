using AthatyCore.DTOs;
using AthatyCore.Entities;
using AthatyCore.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AthatyCore.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {
        private readonly ICollectionRepository repository;

        public ProductController(ICollectionRepository repository)
        {
            this.repository = repository;
        }

        //GET /items
        [HttpGet()]
        public IEnumerable<ProductDto> GetProductsAsync()
        {
            var products = repository.AsQueryable<Product>().Select(x => new ProductDto
            {
                Id = x.Id,
                Name = x.Name,
                CategoryId = x.CategoryId
            });
            return products;  
        }

        //GET /items/id=*******
        [HttpGet("{id}")]
        public ActionResult<ProductDto> GetProduct(string id)
        {
            var product = repository.AsQueryable<Product>().FirstOrDefault(x => x.Id == id);
            if (product is null)
                return NotFound();
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                CategoryId = product.CategoryId
            };
        }

        //POST /items
        //Here we return ItemDto although it's a post request, because it's a convention we send back the item that was created
       
        [HttpPost]
        public async Task<ActionResult<ProductDto>> CreateProductAsync(CreatedProductDto productDto)
        {
            Product product = new()
            {
                Name = productDto.Name,
                CategoryId = productDto.CategoryId
            };

            await repository.AddAsync(product);

            return CreatedAtAction(nameof(CreateProductAsync), new { id = product.Id }, new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                CategoryId = product.CategoryId
            });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProductAsync(string id, UpdatedProductDto productDto)
        {
  
            var existingProduct = repository.AsQueryable<Product>().FirstOrDefault(x => x.Id == id);

            if (existingProduct is null)
            {
                return NotFound();
            }

            existingProduct.CategoryId = productDto.CategoryId;
            existingProduct.Name = productDto.Name;

            await repository.UpdateAsync(existingProduct);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProductAsync(string id)
        {
            var existingProduct = repository.AsQueryable<Product>().FirstOrDefault(x => x.Id == id);

            if (existingProduct is null)
            {
                return NotFound();
            }

            await repository.DeleteAsync(existingProduct);

            return NoContent();
        }
        
    }
}