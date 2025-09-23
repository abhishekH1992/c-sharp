using CryptoMarket.Models;
using CryptoMarket.Interfaces;

namespace CryptoMarket.Repositories
{
    // Wallet repository implementation
    public class WalletRepository : IWalletRepository
    {
        private readonly List<Wallet> _wallets;

        public WalletRepository()
        {
            _wallets = new List<Wallet>();
        }

        public void AddWallet(Wallet wallet)
        {
            if (wallet == null)
                throw new ArgumentNullException(nameof(wallet));
            
            _wallets.Add(wallet);
        }

        public List<Wallet> GetWalletsByUserId(Guid userId)
        {
            return _wallets.Where(w => w.UserId == userId).ToList();
        }

        public List<Wallet> GetAllWallets()
        {
            return _wallets.ToList();
        }

        public Wallet? GetWalletById(Guid walletId)
        {
            return _wallets.FirstOrDefault(w => w.WalletId == walletId);
        }
    }
}
