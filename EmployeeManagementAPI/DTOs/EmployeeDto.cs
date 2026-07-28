namespace EmployeeManagement.API.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public decimal Salary { get; set; }

        public string Department { get; set; } = string.Empty;

        public List<string> Projects { get; set; } = new();
    }
}

