using System.ComponentModel.DataAnnotations;

namespace My.Razor.Store.Domain.Entities
{
    public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }

        public DateTime? Created { get; set; }
        public string? CreatedBy { get; set; }

        public DateTime? Modified { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
