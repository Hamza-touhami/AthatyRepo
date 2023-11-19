using AthatyCore.Entities;

namespace AthatyCore.DTOs
{
    public record CreatedItemDto
    {
        public string Title {get;init;} = null!;
        public string Description { get;init;} = null!;
        public decimal Price { get; init; }
        public string ProductId { get; init; } = null!;
        public AddressInfo Address { get; init; } = null!;
        public List<Image> Images {get; set;} = null!;
    }
}