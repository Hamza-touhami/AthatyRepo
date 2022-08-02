using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AthatyCore.Entities
{
    public record Item
    {
        [Key]
        public Guid Id {get;init;} //init is used for immutable properties
        [ForeignKey("productId")]
        public string? ProductId {get;init;}
        [MaxLength(150)]
        public string Description {get;init;} = null!;
        [Required]
        [Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; init; }
        public DateTimeOffset CreationDate {get;init;}
    }
}