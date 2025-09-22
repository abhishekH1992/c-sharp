public class RegularUser : User {
    private static List<User> _regularUsers = new List<User>();
    
    public RegularUser(string name) : base(name, "Regular") {}
    
    // Implement the abstract method from User base class
    public override bool AddUser(string name, string accountType) {
        try {
            var user = new RegularUser(name);
            _regularUsers.Add(user);
            return true;
        } catch {
            return false;
        }
    }
    
    // Method to get all RegularUser data
    public override List<User> GetUserByType() {
        return _regularUsers.Where(user => user.AccountType == "Regular").ToList();
    }

    public override decimal GetTradingLimit() => 50000m;
    public override bool CanCreateMultipleWallets() => false;
}