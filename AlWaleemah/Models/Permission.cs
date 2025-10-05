using System.ComponentModel.DataAnnotations.Schema;

namespace AlWaleemah.Models
{
    public class Permission
    {
        public int Id { get; set; }

        public bool IsCategory { get; set; } = false;
        public bool IsProduct { get; set; } = false;
        public bool IsEmployee { get; set; } = false;

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public virtual Employee? Employee { get; set; }
    }
}
