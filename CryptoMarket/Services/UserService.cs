using CryptoMarket.Models;
using CryptoMarket.Models.UserTypes;

namespace CryptoMarket.Services
{
    public class UserService {
    private List<User> _users = new List<User>();
    private readonly RegularUser _regularUser;
    private readonly PremiumUser _premiumUser;

    // Dependency Injection Constructor
    public UserService(RegularUser regularUser, PremiumUser premiumUser) {
        _regularUser = regularUser;
        _premiumUser = premiumUser;
        
        // Initialize with seed data
        InitializeWithSeedData();
    }

    // ENCAPSULATION - Private method to initialize with seed data
    private void InitializeWithSeedData()
    {
        // Create seed users directly
        var regularUser1 = new RegularUser("John Doe");
        var regularUser2 = new RegularUser("Jane Smith");
        var regularUser3 = new RegularUser("Bob Johnson");
        var premiumUser1 = new PremiumUser("Alice Brown");
        var premiumUser2 = new PremiumUser("Charlie Wilson");
        
        _users.AddRange(new User[] { regularUser1, regularUser2, regularUser3, premiumUser1, premiumUser2 });
        
        Console.WriteLine($"Initialized with {_users.Count} seed users:");
        Console.WriteLine($"  - Regular: {_users.Count(u => u.AccountType == "Regular")} users");
        Console.WriteLine($"  - Premium: {_users.Count(u => u.AccountType == "Premium")} users");
        Console.WriteLine();
    }

    protected List<User> GetUsers() {
        return _users;
    }

    public User CreateUser()
    {
        Console.WriteLine("Name: ");
        string? name = Console.ReadLine();
        Console.WriteLine("Account Type (Please select correct option):\n"+
                            "1 - Regular Account (Only Spot wallte access)\n"+
                            "2 - Premium Account (Spot and Earn access)");
        if(int.TryParse(Console.ReadLine(), out int choice) && (choice == 1 || choice == 2)) {
            try {
                User user;
                switch(choice) {
                    case 1:
                        user = new RegularUser(name ?? "");
                        // Use injected dependency to add user data
                        bool regularUserAdded = _regularUser.AddUser(name ?? "", "Regular");
                        if (regularUserAdded) {
                            _users.Add(user);
                            Console.WriteLine($"Regular user created successfully: {user.Name} ({user.AccountType})");
                        } else {
                            Console.WriteLine("Failed to add regular user data");
                        }
                        break;
                    case 2:
                        user = new PremiumUser(name ?? "");
                        // Use injected dependency to add user data
                        bool premiumUserAdded = _premiumUser.AddUser(name ?? "", "Premium");
                        if (premiumUserAdded) {
                            _users.Add(user);
                            Console.WriteLine($"Premium user created successfully: {user.Name} ({user.AccountType})");
                        } else {
                            Console.WriteLine("Failed to add premium user data");
                        }
                        break;
                    default:
                        throw new ArgumentException("Invalid account type");
                }
                
                return user;
            } catch(Exception ex) {
                Console.WriteLine($"Oops something went wrong! {ex.Message}");
                throw;
            }
        } else {
            Console.WriteLine("Please enter correct value \n"+
                                "1 - Regular Account (Only Spot wallte access)\n"+
                                "2 - Premium Account (Spot and Earn access)");
            throw new ArgumentException("Invalid input");
        }
    }

    public void GetUserlist() {
        if(_users.Count > 0){
            Console.WriteLine($"{"UserId", -40} {"Name", -20} {"AccountType", -13}");
            Console.WriteLine(new string('-', 75));
            foreach(var user in _users) {
                Console.WriteLine($"{user.UserId, -40} {user.Name, -20} {user.AccountType, -13}");
            }
        } else {
            Console.WriteLine("No user found. Add user to see list.");
        }
    }
    
    public void GetRegularUsers() {
        var regularUsers = _regularUser.GetUserByType();
        if(regularUsers.Count > 0){
            Console.WriteLine($"{"UserId", -40} {"Name", -20} {"AccountType", -13}");
            Console.WriteLine(new string('-', 75));
            foreach(var user in regularUsers) {
                Console.WriteLine($"{user.UserId, -40} {user.Name, -20} {user.AccountType, -13}");
            }
        } else {
            Console.WriteLine("No regular users found.");
        }
    }
    
    public void GetPremiumUsers() {
        var premiumUsers = _premiumUser.GetUserByType();
        if(premiumUsers.Count > 0){
            Console.WriteLine($"{"UserId", -40} {"Name", -20} {"AccountType", -13}");
            Console.WriteLine(new string('-', 75));
            foreach(var user in premiumUsers) {
                Console.WriteLine($"{user.UserId, -40} {user.Name, -20} {user.AccountType, -13}");
            }
        } else {
            Console.WriteLine("No premium users found.");
        }
    }
    }
}