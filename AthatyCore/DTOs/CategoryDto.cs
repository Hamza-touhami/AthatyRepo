namespace AthatyCore.DTOs
{
    public record CategoryDto
    {
        public Guid Id {get;init;} //init is used for immutable properties
        public string Name {get;init;} = null!;
    }
}