using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.API.Entities
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [MaxLength(150)]
        public string Email { get; set; } = string.Empty;

        public decimal Salary { get; set; }

        // Foreign Key
        public int DepartmentId { get; set; }

        // Navigation Property
        public Department? Department { get; set; }

        // One Employee -> Many Projects
        public ICollection<Project> Projects { get; set; } = new List<Project>();
    }
}
