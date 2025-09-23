using CryptoMarket.Events;
using CryptoMarket.Interfaces;

namespace CryptoMarket.Services
{
    // Wallet event handler - subscribes to user creation events
    public class WalletEventHandler : IEventSubscriber
    {
        private readonly IWalletCreationService _walletCreationService;
        private readonly IEventPublisher _eventPublisher;

        public WalletEventHandler(IWalletCreationService walletCreationService, IEventPublisher eventPublisher)
        {
            _walletCreationService = walletCreationService ?? throw new ArgumentNullException(nameof(walletCreationService));
            _eventPublisher = eventPublisher ?? throw new ArgumentNullException(nameof(eventPublisher));
        }

        public void SubscribeToEvents(IEventPublisher publisher)
        {
            publisher.UserCreated += OnUserCreated;
        }

        private void OnUserCreated(object? sender, UserCreatedEventArgs e)
        {
            try
            {
                Console.WriteLine($"User {e.User.Name} created. Creating wallets...");
                
                // Create wallets for the user
                var wallets = _walletCreationService.CreateWalletsForUser(e.User);
                
                // Display wallet creation results
                foreach (var wallet in wallets)
                {
                    Console.WriteLine($"Created {wallet.WalletType} wallet for {e.User.Name}");
                }
                
                Console.WriteLine($"Successfully created {wallets.Count} wallet(s) for {e.User.Name}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating wallets for user {e.User.Name}: {ex.Message}");
            }
        }
    }
}
