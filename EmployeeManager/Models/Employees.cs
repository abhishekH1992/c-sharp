public class Employee {
    public string Name {get; set;}
    public int EmployeeId {get; set;}

    public Employee(string name, int employeeId)
    {
        Name = name;
        EmployeeId = employeeId;
    }
}