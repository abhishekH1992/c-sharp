using CryptoMarket.Models;
using CryptoMarket.Interfaces;

namespace CryptoMarket.Services.Wallet
{
    // Wallet display service implementation - Single Responsibility Principle
    public class WalletDisplayService : IWalletDisplayService
    {
        private readonly IWalletRepository _walletRepository;

        public WalletDisplayService(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository ?? throw new ArgumentNullException(nameof(walletRepository));
        }

        public void DisplayAllWallets()
        {
            var wallets = _walletRepository.GetAllWallets();
            
            if (wallets.Count == 0)
            {
                Console.WriteLine("No wallets found.");
                return;
            }

            Console.WriteLine(new string('-', 100));
            Console.WriteLine("ALL WALLETS");
            Console.WriteLine(new string('-', 100));
            Console.WriteLine($"{"Wallet ID",-36} {"User ID",-36} {"Type",-10} {"Balance",-15} {"Created Date",-20}");
            Console.WriteLine(new string('-', 100));

            foreach (var wallet in wallets)
            {
                DisplayWalletDetails(wallet);
            }

            Console.WriteLine(new string('-', 100));
            Console.WriteLine($"Total Wallets: {wallets.Count}");
            Console.WriteLine(new string('-', 100));
        }

        public void DisplayWalletsByUserId(Guid userId)
        {
            var wallets = _walletRepository.GetWalletsByUserId(userId);
            
            if (wallets.Count == 0)
            {
                Console.WriteLine($"No wallets found for user ID: {userId}");
                return;
            }

            Console.WriteLine(new string('-', 100));
            Console.WriteLine($"WALLETS FOR USER: {userId}");
            Console.WriteLine(new string('-', 100));
            Console.WriteLine($"{"Wallet ID",-36} {"Type",-10} {"Balance",-15} {"Created Date",-20}");
            Console.WriteLine(new string('-', 100));

            foreach (var wallet in wallets)
            {
                Console.WriteLine($"{wallet.WalletId,-36} {wallet.WalletType,-10} ${wallet.Balance,-14:N2} {wallet.CreatedDate:yyyy-MM-dd HH:mm:ss}");
            }

            Console.WriteLine(new string('-', 100));
            Console.WriteLine($"Total Wallets for User: {wallets.Count}");
            Console.WriteLine(new string('-', 100));
        }

        public void DisplayWalletDetails(Models.Wallet wallet)
        {
            if (wallet == null)
            {
                Console.WriteLine("Wallet is null.");
                return;
            }

            Console.WriteLine($"{wallet.WalletId,-36} {wallet.UserId,-36} {wallet.WalletType,-10} ${wallet.Balance,-14:N2} {wallet.CreatedDate:yyyy-MM-dd HH:mm:ss}");
        }
    }
}
