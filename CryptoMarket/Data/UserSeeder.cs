using CryptoMarket.Models;
using CryptoMarket.Models.UserTypes;

namespace CryptoMarket.Data
{
    public class UserSeeder
    {
        private readonly List<User> _seedUsers;

        public UserSeeder()
        {
            _seedUsers = new List<User>();
        }

        // ENCAPSULATION - Private method to create seed data
        private void CreateSeedData()
        {
            // Create Regular Users
            var regularUser1 = new RegularUser("John Doe");
            var regularUser2 = new RegularUser("Jane Smith");
            var regularUser3 = new RegularUser("Bob Johnson");

            // Create Premium Users
            var premiumUser1 = new PremiumUser("Alice Brown");
            var premiumUser2 = new PremiumUser("Charlie Wilson");

            // Add to seed collection
            _seedUsers.AddRange(new User[] { regularUser1, regularUser2, regularUser3, premiumUser1, premiumUser2 });
        }

        // PUBLIC API - Method to get seeded users
        public List<User> GetSeedUsers()
        {
            if (_seedUsers.Count == 0)
            {
                CreateSeedData();
            }
            return _seedUsers.ToList();
        }
    }
}
