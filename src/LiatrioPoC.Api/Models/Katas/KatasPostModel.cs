using System.ComponentModel.DataAnnotations;

namespace LiatrioPoC.Api.Models.Katas
{
    public class KatasPostModel
    {
        /// <summary>
        /// The name of the kata
        /// </summary>
        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }

        /// <summary>
        /// The unique identifier for the category the kata should be under
        /// </summary>
        [Required]
        public Guid CategoryId { get; set; }

        /// <summary>
        /// The description of the kata
        /// </summary>
        [MaxLength(1000)]
        public string? Description { get; set; }
    }
}
