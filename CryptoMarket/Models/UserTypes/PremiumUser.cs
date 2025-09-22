namespace CryptoMarket.Models.UserTypes
{
    public class PremiumUser : User {
    private static List<User> _premiumUsers = new List<User>();

    // Static constructor to initialize seed data
    static PremiumUser() {
        _premiumUsers.Add(new PremiumUser("Alice Brown"));
        _premiumUsers.Add(new PremiumUser("Charlie Wilson"));
    }

    public PremiumUser(string name) : base(name, "Premium") {}
    
    // Implement the abstract method from User base class
    public override bool AddUser(string name, string accountType) {
        try {
            var user = new PremiumUser(name);
            _premiumUsers.Add(user);
            return true;
        } catch {
            return false;
        }
    }
    
    // Method to get all PremiumUser data
    public override List<User> GetUserByType() {
        return _premiumUsers.Where(user => user.AccountType == "Premium").ToList();
    }

    public override decimal GetTradingLimit() => 100000m;
    public override bool CanCreateMultipleWallets() => true;
    }
}