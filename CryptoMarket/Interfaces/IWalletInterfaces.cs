using CryptoMarket.Models;

namespace CryptoMarket.Interfaces
{
    // Wallet repository interface
    public interface IWalletRepository
    {
        void AddWallet(Wallet wallet);
        List<Wallet> GetWalletsByUserId(Guid userId);
        List<Wallet> GetAllWallets();
        Wallet? GetWalletById(Guid walletId);
    }

    // Wallet creation service interface
    public interface IWalletCreationService
    {
        List<Wallet> CreateWalletsForUser(User user);
    }
}
