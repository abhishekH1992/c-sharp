public static class Helper {
    public static bool ValidateInput(string name, string yearInput) {
        if(string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(yearInput)) {
            Console.WriteLine("Please enter name and year data.");
            return false;
        }

        if (!int.TryParse(yearInput, out int year)) {
            Console.WriteLine("Year should be a valid number.");
            return false;
        }
        
        if (year < 1800 || year > DateTime.Now.Year + 5) {
            Console.WriteLine($"Year should be between 1800 and {DateTime.Now.Year + 5}.");
            return false;
        }
        
        return true;
    }
}