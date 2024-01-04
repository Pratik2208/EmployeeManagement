namespace EmployeeManagement.Models.Response
{
    public class GetEmployeeResponse
    {
        public Guid EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public float Salary { get; set; }
        public int DepartmentId { get; set; }
    }
}
