namespace AthatyCore.Entities
{
    public record Product
    {
        public Guid Id {get;init;} //init is used for immutable properties
        public string Name {get;init;} = null!;
        public Guid CategoryId {get;init;}
    }
}