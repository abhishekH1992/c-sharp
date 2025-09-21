public class InputValidation {
    public bool Validate(Employee employee) {
        if (string.IsNullOrEmpty(employee.Name) || employee.EmployeeId <= 0) {
            return false;
        }
        return true;
    }
}