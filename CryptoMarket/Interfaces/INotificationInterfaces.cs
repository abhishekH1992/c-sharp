namespace CryptoMarket.Interfaces
{
    // Delegate for notifications
    public delegate void NotificationDelegate(string recipient, string message);
    
    // Interface for notification service
    public interface INotificationService
    {
        void NotifyWalletCreated(string userName, string accountType, decimal deposit, int walletCount);
    }
}