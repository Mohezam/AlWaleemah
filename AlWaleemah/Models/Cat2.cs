using System.ComponentModel.DataAnnotations;

namespace AlWaleemah.Models
{
    public class Cat2
    {
        //property
        [Key]
        public int Id { get; set; }
        //property
        public int? price { get; set; }

        //علامة الاستفهام معناه // أن الخاصية يمكن أن تكون فارغة (nullable)
        public string? Name { get; set; }

        public string Description { get; set; }
    }
}
