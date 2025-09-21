class EmployeeManager {

    static void Main() {
        var employeeService = new EmployeeService();
        var inputValidation = new InputValidation();
        var displayService = new DisplayService();
        
        bool running = true;
        
        while (running) {
            displayService.ShowMenu();
            Console.Write("Enter your choice (0-5): ");
            
            string? input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) {
                Console.WriteLine("Please enter a valid option.");
                continue;
            }
            
            if (!int.TryParse(input, out int option)) {
                Console.WriteLine("Please enter a valid number.");
                continue;
            }
            
            int[] options = new int[] {0,1,2,3,4,5};
            if (!options.Contains(option)) {
                Console.WriteLine("Please enter a valid option (0-5).");
                continue;
            }

            if (option == 0) {
                Console.WriteLine("Goodbye!");
                running = false;
                break;
            }

            switch(option) {
                case 1: // All employees
                    var allEmployees = employeeService.GetAllEmployees();
                    displayService.ShowAllEmployees(allEmployees);
                    break;

                case 2: // Add New employee
                    Console.Write("Enter employee name: ");
                    string name = Console.ReadLine()!;
                    
                    Console.Write("Enter employee ID: ");
                    string? empIdInput = Console.ReadLine();
                    if (!int.TryParse(empIdInput, out int empId)) {
                        Console.WriteLine("Invalid employee ID. Please enter a number.");
                        break;
                    }
                    
                    var newEmployee = new Employee(name, empId);
                    
                    if(inputValidation.Validate(newEmployee)) {
                        bool result = employeeService.AddEmployee(newEmployee);
                        if(result) {
                            displayService.ShowSuccessMessage("Employee added");
                        } else {
                            displayService.ShowErrorMessage("add employee");
                        }
                    } else {
                        Console.WriteLine("Invalid employee data.");
                    }
                    break;

                case 3: // Update Employee
                    Console.Write("Enter employee ID to update: ");
                    string? updateIdInput = Console.ReadLine();
                    if (!int.TryParse(updateIdInput, out int updateId)) {
                        Console.WriteLine("Invalid employee ID. Please enter a number.");
                        break;
                    }
                    
                    var existingEmployee = employeeService.FindEmployeeById(updateId);
                    if (existingEmployee == null) {
                        displayService.ShowEmployeeNotFound();
                        break;
                    }
                    
                    Console.WriteLine($"Current name: {existingEmployee.Name}");
                    Console.Write("Enter new name: ");
                    string newName = Console.ReadLine()!;
                    
                    bool updateResult = employeeService.UpdateEmployee(updateId, newName);
                    if(updateResult) {
                        displayService.ShowSuccessMessage("Employee updated");
                    } else {
                        displayService.ShowErrorMessage("update employee");
                    }
                    break;

                case 4: // Delete Employee
                    Console.Write("Enter employee ID to delete: ");
                    string? deleteIdInput = Console.ReadLine();
                    if (!int.TryParse(deleteIdInput, out int deleteId)) {
                        Console.WriteLine("Invalid employee ID. Please enter a number.");
                        break;
                    }
                    
                    var employeeToDelete = employeeService.FindEmployeeById(deleteId);
                    if (employeeToDelete == null) {
                        displayService.ShowEmployeeNotFound();
                        break;
                    }
                    
                    Console.WriteLine($"Are you sure you want to delete {employeeToDelete.Name} (ID: {employeeToDelete.EmployeeId})? (y/n)");
                    string confirm = Console.ReadLine()!.ToLower();
                    
                    if (confirm == "y" || confirm == "yes") {
                        bool deleteResult = employeeService.DeleteEmployee(deleteId);
                        if(deleteResult) {
                            displayService.ShowSuccessMessage("Employee deleted");
                        } else {
                            displayService.ShowErrorMessage("delete employee");
                        }
                    } else {
                        Console.WriteLine("Delete operation cancelled.");
                    }
                    break;

                case 5: // Search employee by name
                    Console.Write("Enter name to search: ");
                    string searchName = Console.ReadLine()!;
                    
                    var searchResults = employeeService.SearchEmployeesByName(searchName);
                    displayService.ShowSearchResults(searchResults, searchName);
                    break;

                default:
                    Console.WriteLine($"User selected {option}");
                    break;
            }
            
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}