namespace CryptoMarket.Models
{
    public class Wallet 
    {
        private readonly Guid _walletId;
        private string _walletType;
        private readonly Guid _userId;
        private decimal _balance;
        private DateTime _createdDate;

        public Wallet(string walletType, Guid userId)
        {
            if (string.IsNullOrWhiteSpace(walletType))
                throw new ArgumentException("Wallet type cannot be null or empty", nameof(walletType));
            if (userId == Guid.Empty)
                throw new ArgumentException("User ID cannot be empty", nameof(userId));
                
            _walletId = Guid.NewGuid();
            _walletType = walletType;
            _userId = userId;
            _balance = 0;
            _createdDate = DateTime.Now;
        }

        // Read-only properties
        public Guid WalletId => _walletId;
        public Guid UserId => _userId;
        public DateTime CreatedDate => _createdDate;

        public string WalletType 
        { 
            get { return _walletType; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Wallet type cannot be null or empty");
                _walletType = value;
            }
        }

        public decimal Balance 
        { 
            get { return _balance; }
            set 
            {
                if (value < 0)
                    throw new ArgumentException("Balance cannot be negative");
                _balance = value;
            }
        }

        public string GetWalletInfo()
        {
            return $"Wallet: {_walletType} - Balance: ${_balance:N2} - Created: {_createdDate:yyyy-MM-dd}";
        }
    }
}