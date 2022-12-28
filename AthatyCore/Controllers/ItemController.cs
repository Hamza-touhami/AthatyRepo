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
        [HttpGet]
        public IEnumerable<ItemDto> GetItemsAsync()
        {
            var items = repository.AsQueryable<Item>().Select(x => new ItemDto
            {
                Price = x.Price,
                Description = x.Description,
                CreationDate = x.CreationDate,
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
                Price = item.Price,
                Description = item.Description,
                CreationDate = item.CreationDate,
                Id = item.Id
            };
        }

        //POST /items
        //Here we return ItemDto although it's a post request, because it's a convention we send back the item that was created
       
        [HttpPost]
        public async Task<ActionResult<ItemDto>> CreateItemAsync(CreatedItemDto itemDto)
        {
            Item item = new()
            {
                Price = itemDto.Price,
                Description = itemDto.Description,
                ProductId = itemDto.ProductId
            };

            await repository.AddAsync(item);

            return CreatedAtAction(nameof(CreateItemAsync), new { id = item.Id }, new ItemDto
            {
                Price = item.Price,
                Description = item.Description,
                CreationDate = item.CreationDate,
                ProductId = item.ProductId,
                Id = item.Id
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

            existingItem.Price = itemDto.Price;
            existingItem.Description = itemDto.Description;
            existingItem.ProductId = itemDto.ProductId;


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
        
    }
}