using CryptoMarket.Models;
using CryptoMarket.Interfaces;

namespace CryptoMarket.Services.Wallet
{
    // Wallet creation service
    public class WalletCreationService : IWalletCreationService
    {
        private readonly IWalletRepository _walletRepository;
        private readonly INotificationService _notificationService;

        public WalletCreationService(IWalletRepository walletRepository, INotificationService notificationService)
        {
            _walletRepository = walletRepository ?? throw new ArgumentNullException(nameof(walletRepository));
            _notificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));
        }

        public List<Models.Wallet> CreateWalletsForUser(Models.User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            var wallets = new List<Models.Wallet>();

            // Create wallets based on user type
            if (user.AccountType.Equals("Regular", StringComparison.OrdinalIgnoreCase))
            {
                // Regular users get only Spot wallet
                var spotWallet = new Models.Wallet("Spot", user.UserId);
                wallets.Add(spotWallet);
                _walletRepository.AddWallet(spotWallet);
            }
            else if (user.AccountType.Equals("Premium", StringComparison.OrdinalIgnoreCase))
            {
                // Premium users get both Spot and Earn wallets
                var spotWallet = new Models.Wallet("Spot", user.UserId);
                var earnWallet = new Models.Wallet("Earn", user.UserId);
                
                wallets.Add(spotWallet);
                wallets.Add(earnWallet);
                
                _walletRepository.AddWallet(spotWallet);
                _walletRepository.AddWallet(earnWallet);
            }

            _notificationService.NotifyWalletCreated(user.Name, user.AccountType, user.Deposit, wallets.Count);

            return wallets;
        }
    }
}
