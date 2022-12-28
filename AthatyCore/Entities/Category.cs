using AthatyCore.DTOs;
using System.ComponentModel.DataAnnotations;

namespace AthatyCore.Entities
{
    public record Category : Collection
    {
        [MaxLength(50)] 
        public string Name {get;set;} = null!;

    }
}