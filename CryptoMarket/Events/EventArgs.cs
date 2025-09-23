using CryptoMarket.Models;

namespace CryptoMarket.Events
{
    // Event arguments for user creation
    public class UserCreatedEventArgs : EventArgs
    {
        public User User { get; }
        public DateTime CreatedAt { get; }

        public UserCreatedEventArgs(User user)
        {
            User = user ?? throw new ArgumentNullException(nameof(user));
            CreatedAt = DateTime.Now;
        }
    }
}
