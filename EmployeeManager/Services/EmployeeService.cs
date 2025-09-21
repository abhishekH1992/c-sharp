public class EmployeeService {

    private List<Employee> employees = new List<Employee>();

    public bool AddEmployee(Employee employee) {
        try {
            employees.Add(employee);
            return true;
        } catch(Exception) {
            return false;
        }
    }

    public List<Employee> GetAllEmployees() {
        return employees;
    }

    public bool UpdateEmployee(int employeeId, string newName) {
        try {
            var employee = employees.FirstOrDefault(e => e.EmployeeId == employeeId);
            if (employee != null) {
                employee.Name = newName;
                return true;
            }
            return false;
        } catch(Exception) {
            return false;
        }
    }

    public bool DeleteEmployee(int employeeId) {
        try {
            var employee = employees.FirstOrDefault(e => e.EmployeeId == employeeId);
            if (employee != null) {
                employees.Remove(employee);
                return true;
            }
            return false;
        } catch(Exception) {
            return false;
        }
    }

    public List<Employee> SearchEmployeesByName(string name) {
        try {
            return employees.Where(e => e.Name.ToLower().Contains(name.ToLower())).ToList();
        } catch(Exception) {
            return new List<Employee>();
        }
    }

    public Employee? FindEmployeeById(int employeeId) {
        try {
            return employees.FirstOrDefault(e => e.EmployeeId == employeeId);
        } catch(Exception) {
            return null;
        }
    }
}