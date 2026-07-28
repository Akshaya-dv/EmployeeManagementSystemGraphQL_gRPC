using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.API.Entities
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string ProjectName { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; }

        // Foreign Key
        public int EmployeeId { get; set; }

        // Navigation Property
        public Employee? Employee { get; set; }
    }
}
