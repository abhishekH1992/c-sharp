using CryptoMarket.Models;
using CryptoMarket.Models.UserTypes;
using CryptoMarket.Interfaces;

namespace CryptoMarket.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users;

        public UserRepository()
        {
            _users = new List<User>();
        }

        public void AddUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            
            _users.Add(user);
        }

        public List<User> GetAllUsers()
        {
            return _users.ToList(); // Return copy to prevent external modification
        }

        public List<User> GetUsersByType(string accountType)
        {
            if (string.IsNullOrWhiteSpace(accountType))
                throw new ArgumentException("Account type cannot be null or empty", nameof(accountType));

            return _users.Where(u => u.AccountType.Equals(accountType, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public User? GetUserById(Guid userId)
        {
            return _users.FirstOrDefault(u => u.UserId == userId);
        }

        public void InitializeWithSeedData()
        {
            // Add seed users
            _users.AddRange(new User[] 
            {
                new RegularUser("John Doe", 15000m),
                new RegularUser("Jane Smith", 25000m),
                new RegularUser("Bob Johnson", 12000m),
                new PremiumUser("Alice Brown", 50000m),
                new PremiumUser("Charlie Wilson", 75000m)
            });
        }
    }
}
