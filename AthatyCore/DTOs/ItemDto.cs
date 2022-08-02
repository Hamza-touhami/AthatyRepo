namespace AthatyCore.DTOs
{
    public record ItemDto
    {
        public Guid Id {get;init;} //init is used for immutable properties
        
        public string Description { get;init;} = null!;
        public decimal Price {get;init;}
        public DateTimeOffset CreationDate {get;init;}
    }
}