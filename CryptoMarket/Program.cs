internal class CryptoMarket {
    static void Main() {
        Console.WriteLine(new string('-', 75));
        Console.WriteLine(new string('-', 75));
        Console.WriteLine("Welcome to Crypto World!");
        Console.WriteLine(new string('-', 75));
        Console.WriteLine(new string('-', 75));
        
        bool isRunning = true;
        var displayService = new DisplayService();

        // Dependency Injection - Create instances and inject them
        var regularUser = new RegularUser("temp");
        var premiumUser = new PremiumUser("temp");
        var userService = new UserService(regularUser, premiumUser);

        while (isRunning) {
            int option = displayService.MainMenu();

            switch(option) {
                case 0:
                    Console.WriteLine(new string('-', 75));
                    Console.WriteLine("Thank you for visting Crypto world");
                    Console.WriteLine(new string('-', 75));
                    isRunning = false;
                    break;
                case 1:
                    userService.CreateUser();
                    break;
                case 2:
                    userService.GetUserlist();
                    break;
                case 3:
                    userService.GetRegularUsers();
                    break;
                case 4:
                    userService.GetPremiumUsers();
                    break;
                default:
                    Console.WriteLine("Please select correct option");
                    break;
            }
        }
    }
}