namespace CryptoMarket.Models
{
    public abstract class User 
    {
        // ENCAPSULATION - Private fields with controlled access
        private readonly Guid _userId;
        private string _name = string.Empty;
        private DateTime _createdDate;
        private string _accountType;
        private decimal _deposit;

        // Constructor - Initialize private fields
        public User(string name, string accountType, decimal deposit)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null or empty", nameof(name));

            if (string.IsNullOrWhiteSpace(accountType))
                throw new ArgumentException("Account Type cannot be null or empty", nameof(accountType));

            if (deposit < 10000)
                throw new ArgumentException("Minimum deposit must be at least $10,000", nameof(deposit));
                
            _userId = Guid.NewGuid();
            _name = name;
            _accountType = accountType;
            _deposit = deposit;
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

        public decimal Deposit 
        { 
            get { return _deposit; }
            set 
            {
                if (value < 10000)
                    throw new ArgumentException("Minimum deposit must be at least $10,000");
                _deposit = value;
            }
        }

        // Read-only properties - no setters
        public Guid UserId => _userId;
        public DateTime CreatedDate => _createdDate;

        // Business logic methods - specific to user behavior
        public abstract decimal GetTradingLimit();
        public abstract bool CanCreateMultipleWallets();
        
        public string GetUserInfo()
        {
            return $"User: {_name} (ID: {_userId}) - Created: {_createdDate:yyyy-MM-dd} - Account Type: {AccountType} - Deposit: ${_deposit:N2}";
        }
    }
}