using System.ComponentModel.DataAnnotations;

namespace AlWaleemah.Models
{
    public class Category
    {
        //property
        [Key]
        public int Id { get; set; }
        //property
        [Range(10, 100)]
        public int? price { get; set; }

        //علامة الاستفهام معناه // أن الخاصية يمكن أن تكون فارغة (nullable)
        public string? Name { get; set; }

        public string Description { get; set; }
    }
}
