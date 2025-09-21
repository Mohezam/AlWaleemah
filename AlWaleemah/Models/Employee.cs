using System.ComponentModel.DataAnnotations;

namespace AlWaleemah.Models
{
    public class Employee
    {
       [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }


        public string Username { get; set; }
        public string Password { get; set; }
        public string Address { get; set; } = null;
        public double Salary { get; set; } = 0;

        public bool Islock { get; set; } = false;
        public bool IsDelete { get; set; } = false;
        public int? UserDelete { get; set; }
        public DateTime? DeleteDate { get; set; }
        public DateTime AddDate { get; set; } = DateTime.Now;

        public int? UserRoleId { get; set; }


        //public virtual UserRole? UserRole { get; set; }
        //public virtual ICollection<Permission>? Permissions { get; set; }
        //public string PhoneNumber { get; set; }
        //public DateTime DateOfBirth { get; set; }
        //public string Address { get; set; }
        //public string Position { get; set; }
        //public decimal Salary { get; set; }
        //public DateTime HireDate { get; set; }
        //public string? Notes { get; set; }
    }
}
