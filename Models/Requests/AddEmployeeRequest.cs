namespace EmployeeManagement.Models.Requests
{
    public class AddEmployeeRequest
    {
        public string EmployeeName { get; set; }
        public float Salary { get; set; }
        public int DepartmentId { get; set; }
    }
}
