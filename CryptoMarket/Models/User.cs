namespace CryptoMarket.Models
{
    public abstract class User {
    // ENCAPSULATION - Private fields with controlled access
    private readonly Guid _userId;
    private string _name = string.Empty;
    private DateTime _createdDate;
    private string _accountType;

    // Constructor - Initialize private fields
    public User(string name, string accountType)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be null or empty", nameof(name));

        if (string.IsNullOrWhiteSpace(accountType))
            throw new ArgumentException("Account Type cannot be null or empty", nameof(accountType));
            
        _userId = Guid.NewGuid();
        _name = name;
        _accountType = accountType;
        _createdDate = DateTime.Now;
    }

    // ENCAPSULATION - Controlled access to private data
    public string Name 
    { 
        get { return _name; }
        set 
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Name cannot be null or empty");
            _name = value;
        }
    }
    public string AccountType 
    { 
        get { return _accountType; }
        set 
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Account Type cannot be null or empty");
            _accountType = value;
        }
    }

    // Read-only property - no setter
    public Guid UserId => _userId;

    // Read-only property
    public DateTime CreatedDate => _createdDate;

    public string GetUserInfo()
    {
        return $"User: {_name} (ID: {_userId}) - Created: {_createdDate:yyyy-MM-dd} - Account Type: {AccountType}";
    }

    public abstract bool AddUser(string name, string accountType);
    public abstract List<User> GetUserByType();
    
    // Abstract methods for user-specific behavior
    public abstract decimal GetTradingLimit();
    public abstract bool CanCreateMultipleWallets();
    }
}