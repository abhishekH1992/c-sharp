public class Wallet {
    private Guid _walletId;
    private string _walletType;

    public Wallet(string walletType) {
        if (string.IsNullOrWhiteSpace(walletType))
            throw new ArgumentException("Wallet type cannot be null or empty");
            
        _walletId = Guid.NewGuid();
        _walletType = walletType;
    }
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
}