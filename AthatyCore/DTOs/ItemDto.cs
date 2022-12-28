namespace AthatyCore.DTOs
{
    public record ItemDto
    {
        public string Id { get; init; } = null!;
        public string Description { get;init;} = null!;
        public decimal Price {get;init;}
        public DateTimeOffset CreationDate {get;init;}
        public string ProductId { get; init; } = null!;

    }
}