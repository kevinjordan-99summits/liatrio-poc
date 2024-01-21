using System.ComponentModel.DataAnnotations;

namespace LiatrioPoC.Api.Models.Katas
{
    public class KatasPostModel
    {
        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        [MaxLength(1000)]
        public string? Description { get; set; }
    }
}
