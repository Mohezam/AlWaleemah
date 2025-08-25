using System.ComponentModel.DataAnnotations;

namespace AlWaleemah.Models
{
    public class CategorySecond
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int DisolayOrder { get; set; }
    }
}
// This class represents a second-level category in the application.
// It contains properties for the category ID, name, and display order.
// The Id property is the primary key and is required.
// The Name property is also required, and the DisolayOrder property indicates the order in which the category should be displayed.
// The [Key] attribute indicates that the Id property is the primary key for this entity.
    
