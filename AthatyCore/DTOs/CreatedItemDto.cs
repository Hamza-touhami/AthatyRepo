using AthatyCore.Entities;

namespace AthatyCore.DTOs
{
    public record CreatedItemDto
    {
        public string Description { get;init;} = null!;
        public decimal Price { get; init; }
        public string ProductId { get; init; } = null!;
        public AddressInfo Address { get; init; } = null!;
    }
}