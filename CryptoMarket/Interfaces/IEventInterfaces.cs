using CryptoMarket.Events;

namespace CryptoMarket.Interfaces
{
    // Event publisher interface - Interface Segregation Principle
    public interface IEventPublisher
    {
        event EventHandler<UserCreatedEventArgs>? UserCreated;
        
        void PublishUserCreated(UserCreatedEventArgs args);
        
        // Only keep the method that's actually used
        void UnsubscribeAll();
    }

    // Event subscriber interface
    public interface IEventSubscriber
    {
        void SubscribeToEvents(IEventPublisher publisher);
    }
}