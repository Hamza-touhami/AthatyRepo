namespace AthatyCore.DTOs
{
    public record CreatedProductDto
    {
        public string Name {get;init;} = null!;
        public string CategoryId {get;init;}
    }
}