using AthatyCore.DTOs;
using AthatyCore.Entities;
using AthatyCore.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AthatyCore.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemController : ControllerBase
    {
        private readonly ICollectionRepository repository;

        public ItemController(ICollectionRepository repository)
        {
            this.repository = repository;
        }

        //GET /items
        [HttpGet("getItems")]
        public IEnumerable<ItemDto> GetItemsAsync()
        {
            var items = repository.AsQueryable<Item>().Select(x => new ItemDto
            {
                Images= x.Images,
                Title= x.Title,
                Price = x.Price,
                Description = x.Description,
                CreationDate = x.CreationDate,
                ProductId = x.ProductId,
                Address = x.Address,
                Id = x.Id
            });
            return items;
        }

        //GET /items/id=*******
        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(string id)
        {
            var item = repository.AsQueryable<Item>().FirstOrDefault(x => x.Id == id);
            if (item is null)
                return NotFound();

            return new ItemDto
            {
                Title= item.Title,
                Price = item.Price,
                Description = item.Description,
                CreationDate = item.CreationDate,
                Id = item.Id,
                Address = item.Address,
                ProductId = item.ProductId,
                Images= item.Images
            };
        }

        //POST /items
        //Here we return ItemDto although it's a post request, because it's a convention we send back the item that was created
       
        [HttpPost]
        public async Task<ActionResult<ItemDto>> CreateItemAsync(CreatedItemDto itemDto)
        {
            Item item = new()
            {
                Title= itemDto.Title,
                Price = itemDto.Price,
                Description = itemDto.Description,
                ProductId = itemDto.ProductId,
                Address = itemDto.Address,
                Images= itemDto.Images
            };

            await repository.AddAsync(item);

            return CreatedAtAction(nameof(CreateItemAsync), new { id = item.Id }, new ItemDto
            {
                Price = item.Price,
                Description = item.Description,
                CreationDate = item.CreationDate,
                ProductId = item.ProductId,
                Id = item.Id,
                Images= item.Images
            });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateItemAsync(string id, UpdatedItemDto itemDto)
        {
            var existingItem= repository.AsQueryable<Item>().FirstOrDefault(x => x.Id == id);

            if (existingItem is null)
            {
                return NotFound();
            }

            existingItem.Title = itemDto.Title;
            existingItem.Price = itemDto.Price;
            existingItem.Description = itemDto.Description;
            existingItem.ProductId = itemDto.ProductId;
            existingItem.Images = itemDto.Images;

            await repository.UpdateAsync(existingItem);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItemAsync(string id)
        {
            var existingItem = repository.AsQueryable<Item>().FirstOrDefault(x => x.Id == id);

            if (existingItem is null)
            {
                return NotFound();
            }

            await repository.DeleteAsync(existingItem);

            return NoContent();
        }

        [HttpGet("getCities")]
        public IEnumerable<string> GetCities()
        {
            var cities = repository.AsQueryable<Item>()
                ?.Select(x => x.Address.City)?.Where(x => !string.IsNullOrEmpty(x)).Distinct();

            return cities;
        }
        
    }
}