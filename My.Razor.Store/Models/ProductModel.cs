using System.ComponentModel.DataAnnotations;

namespace My.Razor.Store.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Name { get; set; } = string.Empty;

        [StringLength(100)]
        public string Description { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        [Range(0.01, 100)]
        public decimal Price { get; set; }

        public bool IsAvailable { get; set; }
    }
}
