using AthatyCore.DTOs;
using AthatyCore.Entities;
using AthatyCore.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AthatyCore.Controllers
{
    [ApiController]
    [Route("categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        //GET /items
        [HttpGet]
        public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
        {
            var items = (await categoryRepository.GetCategoriesAsync()).Select(category => category.AsDTO());
            
            return items;
        }

        //GET /items/id=*******
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategoryAsync(Guid id)
        {
            var category = (await categoryRepository.GetCategoryAsync(id)).AsDTO();
            if(category is null)
                return NotFound();
            return category;
        }

        //POST /items
        //Here we return ItemDto although it's a post request, because it's a convention we send back the item that was created
       
        [HttpPost]
        public async Task<ActionResult<CategoryDto>> CreateCategoryAsync(CreatedCategoryDto categoryDto)
        {
            Category category = new()
            {
                Name = categoryDto.Name,
                Id = Guid.NewGuid(),
            };

            await categoryRepository.AddCategoryAsync(category);

            return CreatedAtAction(nameof(CreateCategoryAsync), new {id = category.Id}, category.AsDTO());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCategoryAsync(Guid id, UpdatedCategoryDto itemDto)
        {
            var existingCategory = await categoryRepository.GetCategoryAsync(id);

            if(existingCategory is null)
            {
                return NotFound();
            }
            
            Category updateCategory = existingCategory with
            {
                Name = itemDto.Name,
            };

            await categoryRepository.UpdateCategoryAsync(updateCategory);
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategoryAsync(Guid id)
        {
            var existingCategory = await categoryRepository.GetCategoryAsync(id);
            if(existingCategory is null)
            {
                return NotFound();
            }

            await categoryRepository.DeleteCategoryAsync(existingCategory);

            return NoContent();
        }
        
    }
}