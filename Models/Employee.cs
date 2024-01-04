namespace EmployeeManagement.Models
{
    // Dependent Entity
    // Employee should be associated with any of the Department
    public class Employee
    {
        public Guid EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public float Salary { get; set; }

        // Navigational Properties
        public int DepartmentId { get; set; }
        public Department Department { get; set; } = null!;
    }
}
