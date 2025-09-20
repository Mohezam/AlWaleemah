using System.ComponentModel.DataAnnotations;

namespace AlWaleemah.Models
{
    public class selesReport
    {

        //property
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Summary { get; set; }
        [Required]
        public DateTime Created { get; set; }
        = DateTime.MinValue;
        [Required]
        public DateTime Updated { get; set; }
        = DateTime.MinValue;
        [Required]
        public DateTime LastUpdated { get; set; }
        = DateTime.MinValue;
        [Required]
        public DateTime LastUpdatedUtc { get; set; } = DateTime.MinValue;
        [Required]
        public DateTime LastUpdatedUtcUtcUtc { get; } = DateTime.MinValue;

        

    
                
                
    }
}
