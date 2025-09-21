# Employee Manager

A console-based employee management system built with C# that demonstrates Object-Oriented Programming principles with in-memory data storage.

## Features

- **Add Employees**: Create new employee records with name and ID
- **View All Employees**: Display all employees in a formatted table
- **Update Employees**: Modify existing employee information
- **Delete Employees**: Remove employees with confirmation
- **Search Employees**: Find employees by name (case-insensitive)
- **Input Validation**: Robust error handling for all user inputs
- **Professional UI**: Clean menu system with formatted output

## Project Structure

```
EmployeeManager/
├── Program.cs                    // Main application entry point
├── Models/
│   └── Employees.cs              // Employee data model
├── Services/
│   ├── EmployeeService.cs        // Business logic and data operations
│   └── DisplayService.cs         // UI and display management
└── Utils/
    └── InputValidation.cs         // Input validation logic
```

## Getting Started

### Prerequisites
- .NET 9.0 SDK or later
- Visual Studio, VS Code, or any C# IDE

### Running the Application

1. **Clone or download** the project
2. **Navigate** to the EmployeeManager directory
3. **Run** the application:
   ```bash
   dotnet run
   ```

### How to Use

1. **Start the application** - You'll see the main menu
2. **Choose an option** (0-5):
   - **0**: Exit the application
   - **1**: View all employees
   - **2**: Add new employee
   - **3**: Update existing employee
   - **4**: Delete employee
   - **5**: Search employees by name
3. **Follow the prompts** for each operation
4. **Press any key** to return to the menu after each operation

## Sample Usage

```
=== Employee Manager ===
Enter option: 
0 - Exit 
1 - All employees 
2 - Add New employee 
3 - Update Employee 
4 - Delete Employee 
5 - Search employee by name

Enter your choice (0-5): 2
Enter employee name: John Smith
Enter employee ID: 1001
Employee added successfully!

Press any key to continue...
```

## Technical Details

### Architecture
- **Service-Oriented Design**: Each service has a single responsibility
- **In-Memory Storage**: Data persists during program session
- **Exception Handling**: Comprehensive error handling for all inputs
- **Input Validation**: Safe parsing using TryParse methods

### Key Components

#### Models
- **Employee**: Represents employee data with Name and EmployeeId properties

#### Services
- **EmployeeService**: Handles all business logic including CRUD operations
- **DisplayService**: Manages all UI output and formatting

#### Utils
- **InputValidation**: Validates employee data before processing

### OOP Concepts Demonstrated

- **Classes**: Employee, EmployeeService, DisplayService, InputValidation
- **Objects**: Creating instances of classes
- **Constructors**: Parameterized constructor for Employee
- **Properties**: Name and EmployeeId properties
- **Encapsulation**: Private fields with public methods
- **Methods**: Instance methods for business operations
- **Collections**: List<Employee> for data storage
- **Exception Handling**: Try-catch blocks for error management

## Data Operations

### Add Employee
- Prompts for name and ID
- Validates input data
- Stores employee in memory
- Provides success/failure feedback

### View All Employees
- Displays employees in formatted table
- Shows total count
- Handles empty list gracefully

### Update Employee
- Finds employee by ID
- Shows current information
- Prompts for new data
- Updates employee record

### Delete Employee
- Finds employee by ID
- Shows confirmation prompt
- Removes employee from list
- Provides feedback

### Search Employees
- Case-insensitive name search
- Returns all matching employees
- Displays results in formatted table

## Input Validation

The application handles various error scenarios:
- **Empty Input**: Prompts for valid input
- **Invalid Numbers**: Shows error message for non-numeric IDs
- **Invalid Options**: Validates menu choices
- **Missing Employees**: Handles searches for non-existent employees

## Error Handling

- **Safe Parsing**: Uses TryParse instead of Parse to prevent crashes
- **Graceful Degradation**: Continues running after errors
- **User-Friendly Messages**: Clear error descriptions
- **Input Retry**: Allows users to correct mistakes

## File Structure Details

### Program.cs
- Main application entry point
- Menu loop with input validation
- Coordinates between services
- Handles user interactions

### Models/Employees.cs
- Employee class definition
- Properties for Name and EmployeeId
- Parameterized constructor

### Services/EmployeeService.cs
- CRUD operations for employees
- In-memory data storage
- LINQ queries for searching
- Exception handling for all operations

### Services/DisplayService.cs
- Menu display
- Formatted table output
- Success/error messages
- User feedback

### Utils/InputValidation.cs
- Employee data validation
- Checks for valid names and IDs
- Returns validation results

## Learning Outcomes

This project demonstrates:
- **C# Fundamentals**: Classes, objects, properties, methods
- **Object-Oriented Programming**: Encapsulation, separation of concerns
- **Service Architecture**: Modular design with single responsibilities
- **Input Validation**: Safe parsing and error handling
- **Collections**: List management and LINQ operations
- **Exception Handling**: Try-catch blocks and graceful error management
- **User Interface**: Console-based menu system
- **Data Management**: In-memory CRUD operations

## Future Enhancements

Potential improvements for future versions:
- **File Persistence**: Save/load employees from files
- **Database Integration**: Connect to SQL database
- **Advanced Search**: Search by multiple criteria
- **Employee Categories**: Different types of employees
- **Reporting**: Generate employee reports
- **Bulk Operations**: Import/export multiple employees
- **Data Validation**: More comprehensive validation rules

## Development Notes

- **Time Spent**: 3 hours
- **Architecture**: Service-based design
- **Data Storage**: In-memory List<Employee>
- **Error Handling**: Comprehensive TryParse usage
- **UI**: Console-based with formatted output

## Time Spent
- 3 hours

This project serves as an excellent example of basic OOP principles and console application development in C#.
