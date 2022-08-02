using AthatyCore.DTOs;
using AthatyCore.Entities;
using AthatyCore.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AthatyCore.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository itemRepository;

        public ItemController(IItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }

        //GET /items
        [HttpGet]
        public async Task<IEnumerable<ItemDto>> GetItemsAsync()
        {
            var items = (await itemRepository.GetItemsAsync()).Select(item => item.AsDTO());
            return items;
        }

        //GET /items/id=*******
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetItemAsync(Guid id)
        {
            var item = (await itemRepository.GetItemAsync(id)).AsDTO();
            if(item is null)
                return NotFound();
            return item;
        }

        //POST /items
        //Here we return ItemDto although it's a post request, because it's a convention we send back the item that was created
       
        [HttpPost]
        public async Task<ActionResult<ItemDto>> CreateItemAsync(CreatedItemDto itemDto)
        {
            Item item = new()
            {
                Description = itemDto.Description,
                Price = itemDto.Price,
                Id = Guid.NewGuid(),
                CreationDate = DateTimeOffset.UtcNow
            };

            await itemRepository.AddItemAsync(item);

            return CreatedAtAction(nameof(CreateItemAsync), new {id = item.Id}, item.AsDTO());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateItemAsync(Guid id, UpdatedItemDto itemDto)
        {
            var existingItem = await itemRepository.GetItemAsync(id);

            if(existingItem is null)
            {
                return NotFound();
            }
            
            Item updateItem = existingItem with
            {
                Description = itemDto.Description,
                Price = itemDto.Price
            };

            await itemRepository.UpdateItemAsync(updateItem);
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItemAsync(Guid id)
        {
            var existingItem = await itemRepository.GetItemAsync(id);
            if(existingItem is null)
            {   
                return NotFound();
            }

            await itemRepository.DeleteItemAsync(existingItem);

            return NoContent();
        }
        
    }
}