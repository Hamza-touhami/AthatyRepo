using AthatyCore.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AthatyCore.Entities
{
    public record Item : Collection
    {
        [ForeignKey("productId")]
        public string? ProductId {get;set;}
        [MaxLength(50)]
         public string Title { get; set; } = null!;
        [MaxLength(150)]
        public string Description {get;set;} = null!;
        [Required]
        [Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; set; }
        public DateTimeOffset CreationDate {get;set;}
        public AddressInfo Address { get; set; } = null!;
        public List<Image> Images {get; set;} = null!;
    }
}