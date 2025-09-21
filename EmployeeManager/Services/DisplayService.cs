public class DisplayService
{
    public void ShowMenu()
    {
        Console.WriteLine("=== Employee Manager ===");
        Console.WriteLine("Enter option: \n"+
                            "0 - Exit \n"+
                            "1 - All employees \n"+
                            "2 - Add New employee \n"+
                            "3 - Update Employee \n"+
                            "4 - Delete Employee \n"+
                            "5 - Search employee by name");
    }

    public void ShowAllEmployees(List<Employee> employees)
    {
        if (employees.Count == 0)
        {
            Console.WriteLine("No employees found.");
            return;
        }

        Console.WriteLine("\n=== All Employees ===");
        Console.WriteLine($"{"ID",-10} {"Name",-20}");
        Console.WriteLine(new string('-', 32));
        
        foreach (var employee in employees)
        {
            Console.WriteLine($"{employee.EmployeeId,-10} {employee.Name,-20}");
        }
        Console.WriteLine($"\nTotal employees: {employees.Count}");
    }

    public void ShowSearchResults(List<Employee> employees, string searchTerm)
    {
        if (employees.Count == 0)
        {
            Console.WriteLine($"No employees found matching '{searchTerm}'.");
            return;
        }

        Console.WriteLine($"\n=== Search Results for '{searchTerm}' ===");
        Console.WriteLine($"{"ID",-10} {"Name",-20}");
        Console.WriteLine(new string('-', 32));
        
        foreach (var employee in employees)
        {
            Console.WriteLine($"{employee.EmployeeId,-10} {employee.Name,-20}");
        }
        Console.WriteLine($"\nFound {employees.Count} employee(s).");
    }

    public void ShowSuccessMessage(string operation)
    {
        Console.WriteLine($"{operation} completed successfully!");
    }

    public void ShowErrorMessage(string operation)
    {
        Console.WriteLine($"Failed to {operation.ToLower()}. Please try again.");
    }

    public void ShowEmployeeNotFound()
    {
        Console.WriteLine("Employee not found.");
    }
}
