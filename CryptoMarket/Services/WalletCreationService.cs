using CryptoMarket.Models;
using CryptoMarket.Interfaces;

namespace CryptoMarket.Services
{
    // Wallet creation service
    public class WalletCreationService : IWalletCreationService
    {
        private readonly IWalletRepository _walletRepository;

        public WalletCreationService(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository ?? throw new ArgumentNullException(nameof(walletRepository));
        }

        public List<Wallet> CreateWalletsForUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            var wallets = new List<Wallet>();

            // Create wallets based on user type
            if (user.AccountType.Equals("Regular", StringComparison.OrdinalIgnoreCase))
            {
                // Regular users get only Spot wallet
                var spotWallet = new Wallet("Spot", user.UserId);
                wallets.Add(spotWallet);
                _walletRepository.AddWallet(spotWallet);
            }
            else if (user.AccountType.Equals("Premium", StringComparison.OrdinalIgnoreCase))
            {
                // Premium users get both Spot and Earn wallets
                var spotWallet = new Wallet("Spot", user.UserId);
                var earnWallet = new Wallet("Earn", user.UserId);
                
                wallets.Add(spotWallet);
                wallets.Add(earnWallet);
                
                _walletRepository.AddWallet(spotWallet);
                _walletRepository.AddWallet(earnWallet);
            }

            return wallets;
        }
    }
}
