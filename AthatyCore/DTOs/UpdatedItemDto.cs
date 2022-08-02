namespace AthatyCore.DTOs
{
    public record UpdatedItemDto
    {
        public string Description { get;init;} = null!;
        public decimal Price {get;init;}
    }
}