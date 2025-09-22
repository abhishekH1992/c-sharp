namespace CryptoMarket.Models.UserTypes
{
    public class PremiumUser : User 
    {
        public PremiumUser(string name, decimal deposit) : base(name, "Premium", deposit) {}

        // Business logic specific to PremiumUser
        public override decimal GetTradingLimit() => 100000m;
        public override bool CanCreateMultipleWallets() => true;
    }
}