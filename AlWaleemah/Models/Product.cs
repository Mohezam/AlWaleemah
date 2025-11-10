using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlWaleemah.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string Uid { get; set; } = Guid.NewGuid().ToString();

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        // Foreign Key
        public int CategoryId { get; set; }

        // Navigation Property
        public virtual Category? Category { get; set; }

        public int Quantity { get; set; }

        public string? Description { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        public string? ImageUrl { get; set; }
    }
}
