using CryptoMarket.Models;

namespace CryptoMarket.Interfaces
{
    // Wallet display service interface - Single Responsibility Principle
    public interface IWalletDisplayService
    {
        void DisplayAllWallets();
        void DisplayWalletsByUserId(Guid userId);
        void DisplayWalletDetails(Wallet wallet);
    }
}
