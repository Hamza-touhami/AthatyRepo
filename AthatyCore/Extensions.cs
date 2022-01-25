using AthatyCore.DTOs;
using AthatyCore.Entities;

namespace AthatyCore
{
    public static class Extensions
    {
        public static ItemDto AsDTO(this Item item)
        {
            return new ItemDto
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                CreationDate = item.CreationDate
            };
        }

        public static CategoryDto AsDTO(this Category category)
        {
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public static ProductDto AsDTO(this Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                CategoryId = product.CategoryId
            };
        }
    }
}