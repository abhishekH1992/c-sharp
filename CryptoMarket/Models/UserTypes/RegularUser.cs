namespace CryptoMarket.Models.UserTypes
{
    public class RegularUser : User 
    {
        public RegularUser(string name, decimal deposit) : base(name, "Regular", deposit) {}

        // Business logic specific to RegularUser
        public override decimal GetTradingLimit() => 50000m;
        public override bool CanCreateMultipleWallets() => false;
    }
}