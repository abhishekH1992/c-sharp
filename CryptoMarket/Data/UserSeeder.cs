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
            var regularUser1 = new RegularUser("John Doe", 15000m);
            var regularUser2 = new RegularUser("Jane Smith", 25000m);
            var regularUser3 = new RegularUser("Bob Johnson", 12000m);

            // Create Premium Users
            var premiumUser1 = new PremiumUser("Alice Brown", 50000m);
            var premiumUser2 = new PremiumUser("Charlie Wilson", 75000m);

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
