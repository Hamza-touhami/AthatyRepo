namespace AthatyCore.DTOs
{
    public record CreatedProductDto
    {
        public string Name {get;init;} = null!;
        public Guid CategoryId {get;init;}
    }
}