namespace EmployeeManagement.Models.Response
{
    public class GetDepartmentWithEmployeesResponse
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public ICollection<Employee>? Employees { get; } = new List<Employee>();
    }
}
