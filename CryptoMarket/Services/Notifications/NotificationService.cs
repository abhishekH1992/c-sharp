using CryptoMarket.Interfaces;

namespace CryptoMarket.Services.Notifications
{
    public class NotificationService : INotificationService
    {
        private readonly NotificationDelegate _notificationDelegate;

        public NotificationService()
        {
            // Assign the delegate to our notification method
            _notificationDelegate = SendNotification;
        }

        // Method that matches the delegate signature
        private void SendNotification(string recipient, string message)
        {
            Console.WriteLine(new string('-', 60));
            Console.WriteLine("NOTIFICATION");
            Console.WriteLine(new string('-', 60));
            Console.WriteLine($"{message}");
            Console.WriteLine(new string('-', 60));
            Console.WriteLine("Notification sent successfully!");
            Console.WriteLine(new string('-', 60));
        }

        public void NotifyWalletCreated(string userName, string accountType, decimal deposit, int walletCount)
        {
            string recipient = userName;
            string message = $"Hello {userName}! Your {accountType} account with ${deposit:N2} deposit has been created. {walletCount} wallet(s) have been created successfully.";
            
            // Use delegate to send notification
            _notificationDelegate(recipient, message);
        }
    }
}