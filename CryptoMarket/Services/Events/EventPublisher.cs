using CryptoMarket.Events;
using CryptoMarket.Interfaces;

namespace CryptoMarket.Services.Events
{
    // Event publisher implementation - Single Responsibility Principle
    public class EventPublisher : IEventPublisher
    {
        public event EventHandler<UserCreatedEventArgs>? UserCreated;

        public void PublishUserCreated(UserCreatedEventArgs args)
        {
            UserCreated?.Invoke(this, args);
        }

        public void UnsubscribeAll()
        {
            UserCreated = null;
        }
    }
}
