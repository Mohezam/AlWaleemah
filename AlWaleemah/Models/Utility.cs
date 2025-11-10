using System.ComponentModel.DataAnnotations;

namespace AlWaleemah.Models
{
    public class Utility
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "اسم الأداة مطلوب")]
        [Display(Name = "اسم الأداة")]
        public string Name { get; set; }

        [Required(ErrorMessage = "نوع الأداة مطلوب")]
        [Display(Name = "النوع")]
        public UtilityType Type { get; set; }

        [Required(ErrorMessage = "القيمة مطلوبة")]
        [Display(Name = "القيمة")]
        public string Value { get; set; }

        [Display(Name = "الوصف")]
        public string Description { get; set; }

        [Display(Name = "الفئة")]
        public string Category { get; set; }

        [Display(Name = "مفعل")]
        public bool IsActive { get; set; } = true;

        [Display(Name = "تاريخ الإنشاء")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Display(Name = "تاريخ التحديث")]
        public DateTime? UpdatedAt { get; set; }
    }

    public enum UtilityType
    {
        [Display(Name = "لون")]
        Color,

        [Display(Name = "حدود")]
        Border,

        [Display(Name = "حركات")]
        Animation,

        [Display(Name = "أخرى")]
        Other
    }
}

