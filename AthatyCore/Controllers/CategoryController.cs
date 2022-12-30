using AthatyCore.DTOs;
using AthatyCore.Entities;
using AthatyCore.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AthatyCore.Controllers
{
    [ApiController]
    [Route("categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICollectionRepository repository;

        public CategoryController(ICollectionRepository repository)
        {
            this.repository = repository;
        }

        //GET /items
        [HttpGet("getCategories")]
        public IEnumerable<CategoryDto> GetCategoriesAsync()
        {
            var categories = repository.AsQueryable<Category>().Select(x => new CategoryDto
            {
                Name = x.Name,
                Id = x.Id,
            });  
            return categories;
        }

        //GET /items/id=*******
        [HttpGet("{id}")]
        public ActionResult<CategoryDto> GetCategory(string id)
        {
            var category = repository.AsQueryable<Category>().FirstOrDefault(x => x.Id == id);
            if (category is null)
                return NotFound();

            return new CategoryDto
            {
                Name = category.Name,
                Id = category.Id
            };
        }

        //POST /items
        //Here we return ItemDto although it's a post request, because it's a convention we send back the item that was created
       
        [HttpPost]
        public async Task<ActionResult<CategoryDto>> CreateCategoryAsync(CreatedCategoryDto categoryDto)
        {
            Category category = new()
            {
                Name = categoryDto.Name,
            };

            await repository.AddAsync(category);

            return CreatedAtAction(nameof(CreateCategoryAsync), new {id = category.Id}, new Category
            {
                Name = category.Name,
                Id = category.Id
            });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCategoryAsync(string id, UpdatedCategoryDto itemDto)
        {
            var existingCategory = repository.AsQueryable<Category>().FirstOrDefault(x => x.Id == id);

            if(existingCategory is null)
            {
                return NotFound();
            }

            existingCategory.Name = itemDto.Name;

            await repository.UpdateAsync(existingCategory);
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategoryAsync(string id)
        {
            var existingCategory = repository.AsQueryable<Category>().FirstOrDefault(x => x.Id == id);

            if (existingCategory is null)
            {
                return NotFound();
            }


            await repository.DeleteAsync(existingCategory);

            return NoContent();
        }
        
    }
}