using System.ComponentModel.DataAnnotations;

namespace AlWaleemah.Models
{
    public class Category
    {
        //property
        [Key]
        public int Id { get; set; }

        public string Uid { get; set; } = Guid.NewGuid().ToString();

        [Range(10, 100)]
        public int? Price { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        // One-to-Many: Category -> Products
        public ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
// Compare this snippet from AlWaleemah/Repository/IRepoProduct.cs: