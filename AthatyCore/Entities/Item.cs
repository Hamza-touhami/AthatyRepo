namespace AthatyCore.Entities
{
    public record Item
    {
        public Guid Id {get;init;} //init is used for immutable properties
        public string Name {get;init;} = null!;
        public decimal Price {get;init;}
        public DateTimeOffset CreationDate {get;init;}
    }
}