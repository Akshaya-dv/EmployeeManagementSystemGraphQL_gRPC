using EmployeeManagement.API.Data;
using EmployeeManagement.API.Entities;

namespace EmployeeManagement.API.GraphQL
{
    public class Query
    {
        public IQueryable<Employee> GetEmployees([Service] AppDbContext context)
        {
            return context.Employees;
        }

        public Employee? GetEmployee(int id, [Service] AppDbContext context)
        {
            return context.Employees.FirstOrDefault(e => e.Id == id);
        }
    }
}