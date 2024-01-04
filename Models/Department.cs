namespace EmployeeManagement.Models
{
    // Principal Entity
    // Department Can Exist without an Employee
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public ICollection<Employee>? Employees { get; } = new List<Employee>();
    }
}
