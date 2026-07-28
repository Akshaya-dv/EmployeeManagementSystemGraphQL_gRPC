using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.API.Entities
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string DepartmentName { get; set; } = string.Empty;

        // One Department -> Many Employees
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
