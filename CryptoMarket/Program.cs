using CryptoMarket.Services;
using CryptoMarket.Repositories;
using CryptoMarket.Data;
using CryptoMarket.Interfaces;

internal class Program {
    static void Main() {
        Console.WriteLine(new string('-', 75));
        Console.WriteLine(new string('-', 75));
        Console.WriteLine("Welcome to Crypto World!");
        Console.WriteLine(new string('-', 75));
        Console.WriteLine(new string('-', 75));
        
        bool isRunning = true;
        var displayService = new DisplayService();

        // Dependency Injection - Create instances following SOLID principles
        var userRepository = new UserRepository();
        userRepository.InitializeWithSeedData(); // Initialize with seed data
        
        var userValidationService = new UserValidationService();
        var userCreationService = new UserCreationService(userRepository, userValidationService);
        var userDisplayService = new UserDisplayService(userRepository);
        var userInputService = new UserInputService(userValidationService);
        
        var userService = new UserService(userCreationService, userDisplayService, userInputService);
        
        // Market service with dependency injection
        var marketSeeder = new MarketSeeder();
        IMarketService marketService = new MarketService(marketSeeder);

        while (isRunning) {
            int option = displayService.MainMenu();

            switch(option) {
                case 0:
                    Console.WriteLine(new string('-', 75));
                    Console.WriteLine("Thank you for visting Crypto world");
                    Console.WriteLine(new string('-', 75));
                    isRunning = false;
                    break;
                case 100:
                    marketService.DisplayMarkets();
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