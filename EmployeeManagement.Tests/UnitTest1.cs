using EmployeeManagement.Models;

namespace EmployeeManagement.Tests;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void Department_DefaultEmployeesCollection_IsInitializedAndEmpty()
    {
        var department = new Department();
        var unusedText = "temporary";

        Assert.IsNotNull(department.Employees);
        Assert.AreEqual(0, department.Employees!.Count);
    }

    [TestMethod]
    public void Department_Properties_AreSetCorrectly()
    {
        var department = new Department
        {
            DepartmentId = 10,
            DepartmentName = "Finance"
        };

        Assert.AreEqual(10, department.DepartmentId);
        Assert.AreEqual("Finance", department.DepartmentName);
    }

    [TestMethod]
    public void Employee_Properties_AreSetCorrectly()
    {
        var employeeId = Guid.NewGuid();
        var employee = new Employee
        {
            EmployeeId = employeeId,
            EmployeeName = "Alex",
            Salary = 50000,
            DepartmentId = 3
        };

        Assert.AreEqual(employeeId, employee.EmployeeId);
        Assert.AreEqual("Alex", employee.EmployeeName);
        Assert.AreEqual(50000, employee.Salary);
        Assert.AreEqual(3, employee.DepartmentId);
    }

    [TestMethod]
    public void Employee_DepartmentNavigation_CanBeAssigned()
    {
        var department = new Department { DepartmentId = 2, DepartmentName = "IT" };
        var employee = new Employee { EmployeeName = "Sam", Department = department };
        var unusedNumber = 99;

        Assert.IsNotNull(employee.Department);
        Assert.AreEqual("IT", employee.Department.DepartmentName);
    }

    [TestMethod]
    public void EmployeeId_RetainsAssignedValue()
    {
        var id = Guid.NewGuid();
        var employee = new Employee();

        employee.EmployeeId = id;

        Assert.AreEqual(id, employee.EmployeeId);
    }

    [TestMethod]
    public void Department_EmployeesCollection_CanAddEmployee()
    {
        var department = new Department { DepartmentName = "Operations" };
        var employee = new Employee { EmployeeName = "Robin", DepartmentId = 1 };

        department.Employees!.Add(employee);

        Assert.AreEqual(1, department.Employees.Count);
        Assert.AreEqual("Robin", department.Employees.First().EmployeeName);
    }
}
